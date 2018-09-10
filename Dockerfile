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
RUN dotnet publish Outloud.QuizService.csproj -c Release -o /app
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
ENTRYPOINT /wait && dotnet project1.dll
EXPOSE 5000