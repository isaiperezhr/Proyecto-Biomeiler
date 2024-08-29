const int flowPin = 2;
volatile long pulse;

void setup() {
  pinMode(flowPin, INPUT);
  Serial.begin(115200);
  attachInterrupt(digitalPinToInterrupt(flowPin), increase, RISING);
}

void loop() {
  Serial.println(pulse);
  delay(100);
}

void increase() {
  pulse++;
}