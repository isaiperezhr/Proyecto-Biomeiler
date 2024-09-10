// Bibliotecas necesarias
#include "DHT.h"
#include "MAX6675.h"

// Definir el pin de la bomba de agua
const int bombaPin = 4; // Pin de control de la bomba

// Variable para sincronización de tiempos
unsigned long oldTime = 0;

// Variables sensor DHT11
#define DHTPIN 3            // Pin digital conectado al sensor DHT
#define DHTTYPE DHT11       // Definición del tipo de sensor DHT
DHT dht(DHTPIN, DHTTYPE);   // Inicialización del sensor DHT

// Variables termopar biomeiler
const int dataPin = 7;
const int clockPin = 6;
const int selectPin = 5;
MAX6675 thermoCouple(selectPin, dataPin, clockPin);
uint32_t start, stop;

// Variables termopar instrumentado/agua
const int sensorPin = A3; // Pin analógico donde está conectado el amplificador
float voltage = 0.0;
float temperature = 0.0;

// Variables sensor de flujo
#define FLOW_SENSOR_PIN 2   // Pin del sensor de flujo
volatile long pulse = 0;    // Variable de pulsos para la interrupción
float calibrationFactor = 7.1; // Factor de calibración ajustable
float flowRate = 0;         // Tasa de flujo de agua

// Variables sensor humedad inferior
const int DRY1 = 461;
const int WET1 = 135;
float humidity1;            // Valor de humedad
float percentageHumidity1;  // Porcentaje de humedad

// Variables sensor humedad superior
const int DRY2 = 472;
const int WET2 = 172;
float humidity2;            // Valor de humedad
float percentageHumidity2;  // Porcentaje de humedad

// Variables sensor pH
float calibration_value = 23.37;
unsigned long int avgval; 
int buffer_arr[10], temp;

void setup() {
  // Inicializamos puerto serial
  Serial.begin(500000);

  // Inicializamos sensor DHT11
  dht.begin();

  // Inicializamos termopar inferior
  SPI.begin();
  thermoCouple.begin();
  thermoCouple.setSPIspeed(4000000);

  // Configuración para sensor de flujo de agua
  pinMode(FLOW_SENSOR_PIN, INPUT);
  attachInterrupt(digitalPinToInterrupt(FLOW_SENSOR_PIN), increase, RISING);

  // Configuración del pin de la bomba de agua
  pinMode(bombaPin, OUTPUT);
  digitalWrite(bombaPin, LOW); // Apagar la bomba inicialmente

  // LED Integrado
  pinMode(LED_BUILTIN, OUTPUT);
  digitalWrite(LED_BUILTIN, LOW);

  // Pausa para que inicie el sistema
  delay(2000);
}

void ambiental() {
  // Lectura de temperatura y humedad ambiental
  float h = dht.readHumidity();
  float t = dht.readTemperature();

  // Verificar si hay errores de lectura
  if (isnan(h) || isnan(t)) {
    Serial.print(F("NO HUMEDAD")); Serial.print(",");
    Serial.print(F("NO TEMPERATURA")); Serial.print(",");
    return;
  }

  // Imprimir valores leídos del sensor DHT
  Serial.print(h); Serial.print(",");
  Serial.print(t); Serial.print(",");
}

void termopar_bio() {
  int status = thermoCouple.read();
  float temp = thermoCouple.getTemperature();
  //thermoCouple.setOffset(-10.0);

  if (status == 0) {
  Serial.print(temp);
  Serial.print(",");
  }
}

void termopar_agua() {
  int sensorValue = analogRead(sensorPin);  // Leer el valor analógico (0-1023)
  voltage = sensorValue * (5.0 / 1023.0);   // Convertir a voltaje (0-5V)

  // Calcular la temperatura usando la ecuación obtenida
  temperature = 25.64 * voltage - 15.64;

  Serial.print(temperature);
  Serial.print(",");
}

void soil_humidity() {
  // Leer los valores de humedad del suelo
  humidity1 = analogRead(A0);
  humidity2 = analogRead(A1);

  // Convertir los valores analógicos a porcentaje de humedad
  percentageHumidity1 = map(humidity1, WET1, DRY1, 100, 0);
  percentageHumidity2 = map(humidity2, WET2, DRY2, 100, 0);

  // Asegurarse de que los valores estén dentro del rango 0-100%
  percentageHumidity1 = constrain(percentageHumidity1, 0, 100);
  percentageHumidity2 = constrain(percentageHumidity2, 0, 100);

  // Imprimir valores de humedad del suelo
  Serial.print(percentageHumidity1); Serial.print(",");
  Serial.print(percentageHumidity2); Serial.print(",");
}


void flujo_agua() {
  // Calcular la tasa de flujo en L/min
  flowRate = (pulse / calibrationFactor);
  Serial.print(flowRate); Serial.print(",");
  pulse = 0;  // Reiniciar el conteo de pulsos para el siguiente intervalo
}

void increase() {
  pulse++;  // Incrementar la cuenta de pulsos
}

void ph_meter() {
  // Leer 10 valores y almacenarlos en buffer_arr
  for(int i=0; i<10; i++) { 
    buffer_arr[i] = analogRead(A2);
    delay(30);
  }

  // Ordenar el array para filtrar valores atípicos
  for(int i=0; i<9; i++) {
    for(int j=i+1; j<10; j++) {
      if(buffer_arr[i] > buffer_arr[j]) {
        temp = buffer_arr[i];
        buffer_arr[i] = buffer_arr[j];
        buffer_arr[j] = temp;
      }
    }
  }

  // Calcular el promedio de los valores intermedios (descartando los extremos)
  avgval = 0;
  for(int i=2; i<8; i++) {
    avgval += buffer_arr[i];
  }
  
  // Conversión a voltios
  float volt = (float)avgval * 5.0 / 1024 / 6;
  
  // Calcular el pH
  float ph_act = -5.70 * volt + calibration_value;

  Serial.print(ph_act); Serial.println();
}

void loop() {
  // Comprobar si hay datos en el puerto serial
  if (Serial.available() > 0) {
    String comando = Serial.readStringUntil('\n');

    // Procesar el comando recibido
    if (comando == "ENCENDER_BOMBA") {
      digitalWrite(bombaPin, HIGH); // Encender la bomba
      digitalWrite(LED_BUILTIN, HIGH);
    } else if (comando == "APAGAR_BOMBA") {
      digitalWrite(bombaPin, LOW); // Apagar la bomba
      digitalWrite(LED_BUILTIN, LOW);
    }
  }

  // Enviar los datos de los sensores cada segundo
  if (millis() - oldTime > 670) {
    Serial.print(millis() * 0.001); Serial.print(",");
    ambiental();
    termopar_bio();
    termopar_agua();
    soil_humidity();
    flujo_agua();
    ph_meter();
    oldTime = millis();
  }
}
