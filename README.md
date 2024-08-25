# Express Voitures

## Description
Express Voitures est un projet développé dans le cadre du parcours .NET de l'OpenClassrooms.
Ce projet vise à créer une application de gestion de voitures en utilisant les technologies .NET.

## Fonctionnalités
Gestion des voitures :
- ajout
- modification
- suppression
- visualisation des voitures.

## Prérequis
- .NET SDK 8.0
- Visual Studio ou tout autre IDE compatible avec .NET
- SQL Server pour la base de données

## Installation
1. Clonez le dépôt :
   ```bash
   git clone https://github.com/RomainBurel/OCR_DotNet_P5_ExpressVoitures.git
2. Ouvrez le projet dans votre IDE.
3. Restaurez les packages NuGet :
   ```bash
   dotnet restore
4. Configurez la base de données en utilisant le fichier appsettings.json.
5. Appliquez les migrations pour créer la base de données :
   ```bash
   dotnet ef database update

## Utilisation
Lancez l'application via votre IDE ou en utilisant la ligne de commande :
   ```bash
   dotnet run

Accédez à l'application via votre navigateur à l'adresse [https://localhost:7184/].
