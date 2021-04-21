FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

WORKDIR /src

COPY /src/*.sln ./

COPY /src/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ${file%.*} && mv $file ${file%.*}; done
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet build

RUN dotnet test src/Automation.Core.UnitTests --logger:trx