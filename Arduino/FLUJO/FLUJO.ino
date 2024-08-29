const int flowPin = 2;
volatile long pulse;
unsigned long oldTime = 0;
float calibrationFactor = 7.5; // Inicialmente en 0, lo ajustas tras la calibración
float flowRate = 0;

void setup() {
  pinMode(flowPin, INPUT);
  Serial.begin(115200);
  attachInterrupt(digitalPinToInterrupt(flowPin), increase, RISING);
}

void loop() {
  if (millis() - oldTime > 1000) {  // Calcular flujo cada segundo
    flowRate = (pulse / calibrationFactor);  // Convertir pulsos a L/min
    Serial.println("Flow_rate");
    Serial.println(flowRate);
    pulse = 0;  // Reiniciar el conteo de pulsos para el siguiente intervalo
    oldTime = millis();
  }
}

void increase() {
  pulse++;
}
