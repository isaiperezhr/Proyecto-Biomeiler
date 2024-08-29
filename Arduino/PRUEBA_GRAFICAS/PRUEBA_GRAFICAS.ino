void setup() {
  Serial.begin(500000);

}

void loop() {
  double time = millis() * 0.001;
  double value1 = 10 * sin(2 * PI * time);
  double value2 = 9 * sin(2 * PI * time);
  double value3 = 8 * sin(2 * PI * time);
  double value4 = 7 * sin(2 * PI * time);
  double value5 = 6 * sin(2 * PI * time);
  double value6 = 5 * sin(2 * PI * time);

  
  // Enviar los datos en una sola línea, separados por comas
  Serial.print(time);      // Tiempo
  Serial.print(",");       // Separador
  Serial.print(value1);   // Valor de la señal senoidal (Humidity_high)
  Serial.print(",");       // Separador
  Serial.print(value2);   // Valor de la señal senoidal (Humidity_high)
  Serial.print(",");       // Separador
  Serial.print(value3);   // Valor de la señal senoidal (Humidity_high)
  Serial.print(",");       // Separador
  Serial.print(value4);   // Valor de la señal senoidal (Humidity_high)
  Serial.print(",");       // Separador
  Serial.print(value5);   // Valor de la señal senoidal (Humidity_high)
  Serial.print(",");       // Separador
  Serial.println(value6);   // Valor de la señal senoidal (Humidity_high)

  delay(1000);
}

