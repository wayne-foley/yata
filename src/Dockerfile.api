FROM microsoft/dotnet:latest

COPY . /app
WORKDIR /app

RUN ["apt-get", "update"]
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]

EXPOSE 5000/tcp

RUN chmod +x /app/start.sh
CMD /app/start.sh