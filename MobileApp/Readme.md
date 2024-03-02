## Create a Signed and Publishable .NET MAUI Android App in VS2022

0. Abrir solución en visual studio

1. Abrir terminal
View >> Terminal

2. Generación de Certificado autofirmado
```
> keytool -genkey -v -keystore key.keystore -alias DevInterview -keyalg RSA -keysize 2048 -validity 10000
```

	Password: Peru1821*
	First name and laste name: JG
	Organizational unit: Dev
	Organization name: Ambar Labs
	City: Lima
	State: Lima
	country Code: PE
	
3. Abrir la carpeta para visualizar el keystore file (no subir a repositorio)
```
> explorer .	
```

4. Agregar al final del archivo `csproj`. Agregarlo la siguiente porción de código.

<PropertyGroup Condition="$(TargetFramework.Contains('-android')) and '$(Configuration)' == 'Release'">
	<AndroidKeyStore>True</AndroidKeyStore>
	<AndroidSigningKeyStore>.\key.keystore</AndroidSigningKeyStore>
	<AndroidSigningStorePass>NOfumar34*</AndroidSigningStorePass>
	<AndroidSigningKeyAlias>MauiAlias</AndroidSigningKeyAlias>
	<AndroidSigningKeyPass>NOfumar34*</AndroidSigningKeyPass>
</PropertyGroup>

5. En la terminal, ejecutar el siguien comando
```
> dotnet publish -c Release -f:net8.0-android
```


6. Abrir la siguiente carpeta y poner atención a los archivos firmados: .aab y .apk
```
\bin\Release\net8.0-android
```

7. Acceder a "Google Play Console"  https://play.google.com/console/u/1/developers/?pli=1
* Create app
* Internal Testing >> Create new release >> upload .aab file
* Save and Publish
* Choose Testers
* How testers join your test ---> Copy link


