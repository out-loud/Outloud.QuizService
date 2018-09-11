FROM microsoft/dotnet:2.1-sdk-alpine AS build
LABEL stage intermediate
WORKDIR /
COPY Outloud.QuizService/src src
COPY Outloud.QuizService/tests tests
RUN dotnet restore src/Outloud.QuizService.csproj
WORKDIR /src
# build
RUN dotnet build Outloud.QuizService.csproj -c Release -o /app
# publish to /app dir
FROM build AS publish
RUN dotnet publish Outloud.QuizService.csproj -c Release -o /app --source "https://api.nuget.org/v3/index.json" --source "https://www.myget.org/F/outloud/api/v3/index.json"
# copy tests
FROM build AS test
WORKDIR /tests
ADD https://github.com/ufoscout/docker-compose-wait/releases/download/2.3.0/wait /wait
RUN chmod +x /wait
ENTRYPOINT /wait && dotnet test --logger:trx
# publish
FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine AS base
WORKDIR /app
COPY --from=publish /app .
ADD https://github.com/ufoscout/docker-compose-wait/releases/download/2.3.0/wait /wait
RUN chmod +x /wait
ENTRYPOINT /wait && dotnet Outloud.QuizService.dll
EXPOSE 5000