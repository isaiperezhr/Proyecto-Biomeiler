#include <WiFiS3.h>

const char* WIFI_SSID = "";
const char* WIFI_PASSWORD = "";
const char* TCP_SERVER_ADDR = "";
const int TCP_SERVER_PORT = 5000;

WiFiClient TCP_client;

void setup() {
  Serial.begin(9600);

  while (WiFi.begin(WIFI_SSID, WIFI_PASSWORD) != WL_CONNECTED) {
    delay(10000);
  }

  if (TCP_client.connect(TCP_SERVER_ADDR, TCP_SERVER_PORT)) {
    TCP_client.write("Hello!");
    TCP_client.flush();
  }
}

void loop() {
  if (!TCP_client.connected()) {
    TCP_client.stop();
    delay(1000);
    if (TCP_client.connect(TCP_SERVER_ADDR, TCP_SERVER_PORT)) {
      TCP_client.write("Hello!");
      TCP_client.flush();
    }
  }

  double value = sin(millis() * 0.001 * 2 * PI);
  String signal = String(value, 6) + "\n";

  if (TCP_client.connected()) {
    TCP_client.write(signal.c_str());
    TCP_client.flush();
  } else {
    TCP_client.stop();
    delay(1000);
  }

  if (TCP_client.available()) {
    Serial.print(TCP_client.read());
  }

  delay(10);
}
