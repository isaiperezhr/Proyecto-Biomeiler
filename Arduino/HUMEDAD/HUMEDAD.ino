const int dry1 = 461;
const int wet1 = 158;
float humidity1;  // Declarar la variable humidity
float percentageHumidity1;

const int dry2 = 472;
const int wet2 = 187;
float humidity2;  // Declarar la variable humidity
float percentageHumidity2;

void setup() {
  Serial.begin(115200);
}

void loop() {
  humidity1 = analogRead(A0);  // Leer el valor analógico
  humidity2 = analogRead(A1);  // Leer el valor analógico

  percentageHumidity1 = map(humidity1, wet1, dry1, 100, 0);
  percentageHumidity2 = map(humidity2, wet2, dry2, 100, 0);

  Serial.println("Humidity_low");
  Serial.println(percentageHumidity1);   // Imprimir el valor de humedad

  Serial.println("Humidity_high");
  Serial.println(percentageHumidity2);   // Imprimir el valor de humedad

  delay(100);  // Pausar el código durante 100 milisegundos
}
