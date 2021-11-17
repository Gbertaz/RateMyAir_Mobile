# RateMyAir Mobile app
Air quality monitoring system mobile application developed in MAUI. Fetches the data by calling the [RateMyAir APIs](https://github.com/Gbertaz/RateMyAir_API) hosted on a Raspberry Pi. The air data (temperature, humidity, pressure and particulate matter) are collected by an ESP8266 running the [RateMyAir Firmware](https://github.com/Gbertaz/RateMyAir_FW).

Please note that the app uses Syncfusion components which are still at an early stage of development. Adding an SfRadialGauge the app throws the following exception running on the Android emulator (Pixel 5 Android 12.0 - API 31):

```
System.UnauthorizedAccessException: 'Access to the path '/data/fonts' is denied.'
```

Works fine on Android emulator Pixel 5 Android 9.0 - API 28.

# The app is currently under development
