FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
FROM base AS final
WORKDIR /app
COPY CZ.Blog.Ids4.Server/bin/Release/netcoreapp3.1/publish/ .
RUN /bin/cp /usr/share/zoneinfo/Asia/Shanghai /etc/localtime && echo 'Asia/Shanghai' >/etc/timezone
ENTRYPOINT ["dotnet", "CZ.Blog.Ids4.Server.dll"]