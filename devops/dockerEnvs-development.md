# Docker Environment - Development
-----

### Preparing

To execute the following commands, first you need login in Docket Hub. To login in Docker Hub execute the following command:

[IN]:
```
docker login
```
[OUT]:
```
Login Succeeded
```

### Postgres Container

We will create the postgres container with config:

| Name | Value |
|---|---|
| Name | development-postgres |
| Hostname | development-postgres |
| Network | development |
| IP | 172.18.0.2 |
| Port | 6000 |
| Username | postgres |
| Password | postgres |

To create a container with Postgres, execute the following command:

```
docker run --name development-postgres --hostname development-postgres --network development --ip 172.18.0.2 -p 6000:5432 -e POSTGRES_PASSWORD=postgres -d postgres
```

### pgAdmin Container

We will create the pgAdmin container with following config:

| Name | Value |
|---|---|
| Name | development-pgAdmin |
| Hostname | development-pgAdmin |
| Network | development |
| IP | 172.18.14.0 |
| Port | 6140 |
| Username | postgres |
| Password | postgres |

To create a container with pgAdmin, execute the following command:

```
docker run --name development-pgadmin --hostname development-pgadmin --network development --ip 172.18.14.0 -p 6140:80 -e "PGADMIN_DEFAULT_EMAIL=postgres" -e "PGADMIN_DEFAULT_PASSWORD=postgres" -d dpage/pgadmin4
```

### MongoDB Container

We will configure the MongoDB container with following config:

| Name | Value |
|---|---|
| Name | development-mongodb |
| Hostname | development-mongodb |
| Network | development |
| IP | 172.18.0.3 |
| Port | 6001 |
| Username | admin |
| Password | admin |

To create a container with MongoDB, execute the following command:

```
docker run --name development-mongodb --hostname development-mongodb --network development --ip 172.18.0.3 -e MONGO_INITDB_ROOT_USERNAME=admin -e MONGO_INITDB_ROOT_PASSWORD=admin -p 6001:27017 -d mongo
```

### Redis

We will configure Redis container with following config:

| Name | Value |
|---|---|
| Name | development-redis |
| Hostname | development-redis |
| Network | development |
| IP | 172.18.0.4 |
| Port | 6002 |

To create a container with Redis, execute the following command:

```
docker run --name development-redis --hostname development-redis --network development --ip 172.18.0.4 -p 6002:6379 -d redis
```

### Prometheus

We will configure Prometheus container with following config:

| Name | Value |
|---|---|
| Name | development-prometheus |
| Hostname | development-prometheus |
| Network | development |
| IP | 172.18.0.5 |
| Port | 6003 |

To create a container with Prometheus, execute the following command:

```
docker run --name development-prometheus --hostname development-prometheus --network development --ip 172.18.0.5 -p 6003:9090 -d prom/prometheus
```

### RabbitMQ Container

We will configure the RabbitMQ container with following config:

| Name | Value |
|---|---|
| Name | development-rabbitmq |
| Hostname | development-rabbitmq |
| Network | development |
| IP | 172.18.4.0 |
| Port - Management | 6020 |
| Port - AMQP | 6021 |
| Username | guest |
| Password | guest |

To create a container with RabbitMQ, execute the following command:

```
docker run --name development-rabbitmq --hostname development-rabbitmq --network development --ip 172.18.4.0 -p 6020:15672 -p 6021:5672 -d rabbitmq:3-management
```

### Grafana Container

We will configure the Grafana container with following config:

| Name | Value |
|---|---|
| Name | development-grafana |
| Hostname | development-grafana |
| Network | development |
| IP | 172.18.14.1 |
| Port | 6141 |
| Username | admin |
| Password | admin |

To create a container with Grafana, execute the following command:

```
docker run --name development-grafana --hostname development-grafana --network development --ip 172.18.14.1 -p 6141:3000 -d  grafana/grafana
```
