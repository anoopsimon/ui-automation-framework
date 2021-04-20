FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

WORKDIR /Automation.Core

COPY ./*.sln ./

COPY */*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ${file%.*} && mv $file ${file%.*}; done
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet build

RUN dotnet test --logger:trx