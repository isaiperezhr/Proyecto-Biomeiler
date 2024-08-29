// Bibliotecas necesarias
#include "DHT.h"

// Definir el pin de la bomba de agua
const int bombaPin = 7; // Pin de control de la bomba

// Variable para sincronización de tiempos
unsigned long oldTime = 0;

// Variables sensor DHT11
#define DHTPIN 3            // Pin digital conectado al sensor DHT
#define DHTTYPE DHT11       // Definición del tipo de sensor DHT
DHT dht(DHTPIN, DHTTYPE);   // Inicialización del sensor DHT

// Variables sensor de flujo
#define FLOW_SENSOR_PIN 2   // Pin del sensor de flujo
volatile long pulse = 0;    // Variable de pulsos para la interrupción
float calibrationFactor = 7.5; // Factor de calibración ajustable
float flowRate = 0;         // Tasa de flujo de agua

// Variables sensor humedad inferior
const int DRY1 = 785;
const int WET1 = 370;
float humidity1;            // Valor de humedad
float percentageHumidity1;  // Porcentaje de humedad

// Variables sensor humedad superior
const int DRY2 = 785;
const int WET2 = 360;
float humidity2;            // Valor de humedad
float percentageHumidity2;  // Porcentaje de humedad

// Variables sensor pH
float calibration_value = 21.34;
unsigned long int avgval; 
int buffer_arr[10], temp;

void setup() {
  // Inicializamos puerto serial
  Serial.begin(500000);

  // Inicializamos sensor DHT11
  dht.begin();

  // Configuración para sensor de flujo de agua
  pinMode(FLOW_SENSOR_PIN, INPUT);
  attachInterrupt(digitalPinToInterrupt(FLOW_SENSOR_PIN), increase, RISING);

  // Configuración del pin de la bomba de agua
  pinMode(bombaPin, OUTPUT);
  digitalWrite(bombaPin, LOW); // Apagar la bomba inicialmente

  // Pausa para que inicie el sistema
  delay(2000);
}

void ambiental() {
  // Lectura de temperatura y humedad ambiental
  float h = dht.readHumidity();
  float t = dht.readTemperature();

  // Verificar si hay errores de lectura
  if (isnan(h) || isnan(t)) {
    Serial.print(F("Failed to read from DHT sensor!")); Serial.print(",");
    Serial.print(F("No hay valor")); Serial.print(",");
    return;
  }

  // Imprimir valores leídos del sensor DHT
  Serial.print(h); Serial.print(",");
  Serial.print(t); Serial.print(",");
}

void soil_humidity() {
  // Leer los valores de humedad del suelo
  humidity1 = analogRead(A0);
  humidity2 = analogRead(A1);

  // Convertir los valores analógicos a porcentaje de humedad
  percentageHumidity1 = map(humidity1, WET1, DRY1, 100, 0);
  percentageHumidity2 = map(humidity2, WET2, DRY2, 100, 0);

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
  // Leer valores del sensor de pH
  for(int i = 0; i < 10; i++) { 
    buffer_arr[i] = analogRead(A2);
    delay(30);
  }

  // Ordenar los valores leídos
  for(int i = 0; i < 9; i++) {
    for(int j = i + 1; j < 10; j++) {
      if(buffer_arr[i] > buffer_arr[j]) {
        temp = buffer_arr[i];
        buffer_arr[i] = buffer_arr[j];
        buffer_arr[j] = temp;
      }
    }
  }

  avgval = 0;

  // Promediar los valores del sensor de pH
  for(int i = 2; i < 8; i++)
    avgval += buffer_arr[i];
  
  float volt = (float)avgval * 5.0 / 1024 / 6;
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
    } else if (comando == "APAGAR_BOMBA") {
      digitalWrite(bombaPin, LOW); // Apagar la bomba
    }
  }

  // Enviar los datos de los sensores cada segundo
  if (millis() - oldTime > 670) {
    Serial.print(millis() * 0.001); Serial.print(",");
    ambiental();
    soil_humidity();
    flujo_agua();
    ph_meter();
    oldTime = millis();
  }
}
