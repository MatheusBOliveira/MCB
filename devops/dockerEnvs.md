# Docker Environment
-----
### Configure Networks
To configure docker, we need configure docker networks. First, we list all docker networks with command in terminal:

[IN]:
```
docker network ls
```

This command list all networks. We will create the development, testing, stage and production network. If some these network exists in the list, we will remove then with the following command:

```
docker network rm networkName
```

We will creating the networks with the following IPs:

|IP | Network   |
|---|---|
|172.18.X.X/16|Development|
|172.19.X.X/16|Testing|
|172.20.X.X/16|Stage|
|172.21.X.X/16|Production|

For create this networks, execute the commands:

[IN]:
```
docker network create --subnet=172.18.0.0/16 development
docker network create --subnet=172.19.0.0/16 testing
docker network create --subnet=172.20.0.0/16 staging
docker network create --subnet=172.21.0.0/16 production
```

To check network config, execute:

[IN]:
```
docker network inspect networkName
```

### Ports Conventions

To access containers in docker from the host machine, we will map a host machine port to container port. To organize this port mappings, we will use this following pattern:

|Host Ports | Enviorment   |
|---|---|
|6000|Development|
|7000|Testing|
|8000|Stage|
|9000|Production|

### IP Conventions

Any container must have a IP in docker network. Any docker network use two IPs that end with X.X.0.0 and X.X.0.1. To organize the ip range we will use the following pattern:

| Container IP range | Port map range | Description |
|---|---|---|
| xx.xx.0.2 to xx.xx.1.255 | x000 a x019 | Repositories |
| xx.xx.2.0 to xx.xx.3.255 | x020 a x039 | DataServices |
| xx.xx.4.0 to xx.xx.5.255 | x040 a x059 | Queues |
| xx.xx.6.0 to xx.xx.7.255 | x060 a x079 | Consumers |
| xx.xx.8.0 to xx.xx.9.255 | x080 a x099 | Services |
| xx.xx.10.0 to xx.xx.11.255 | x100 a x119 | Gateways |
| xx.xx.12.0 to xx.xx.13.255 | x120 a x139 | Web Apps |
| xx.xx.14.0 to xx.xx.15.255 | x140 a x159 | Other Apps |

### Repositories ports conventions

| Port | Description |
|---|---|
| x000 | Postgres |
| x001 | MongoDB |
| x002 | Redis |
| x003 | InfluxDB |
| x004 | ElasticSearch |

### Queues ports conventions

| Port | Description |
|---|---|
| x020 | RabbitMQ - Management |
| x021 | RabbitMQ - AMQP |

### Gateways ports conventions

| Port | Description |
|---|---|
| x100 | Web App Gateway |
| x101 | Data Service Gateway |

### Other apps
| Port | Description |
|---|---|
| x140 | pgAdmin |
| x141 | Grafana |
| x142 | Graylog |

## Enviorments configs

* <b>Development</b>: To see development docker environment config follow this [link](dockerEnvs-development.md)
* <b>Testing</b>: To see testing docker environment config follow this [link](dockerEnvs-testing.md)
* <b>Stage</b>: To see stage docker environment config follow this [link](dockerEnvs-stage.md)
* <b>Production</b>: To see production docker environment config follow this [link](dockerEnvs-production.md)
