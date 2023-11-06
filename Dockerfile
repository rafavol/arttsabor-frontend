FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

ARG PORT=25200
ENV PORT=${PORT}

ARG BACKEND_PORT=25100
ENV BACKEND_PORT=${BACKEND_PORT}

ENV ASPNETCORE_URLS=http://+:${PORT}
EXPOSE ${PORT}

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . ./
RUN dotnet restore


FROM build AS publish
RUN dotnet publish -c Release -o out

FROM base AS final
WORKDIR /app
COPY --from=publish out .
ENTRYPOINT ["dotnet", "ArttSaborBlazor.dll"]