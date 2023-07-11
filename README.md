Start the app and monitoring:
```powershell
.\up.ps1
```

Run load testing with different concurrency levels (10, 25, 50, 100, 200, 300, 400, 500), 1 minute each:
```powershell
.\test.ps1
```

Turn off the app and monitoring:
```powershell
.\down.ps1
```

## Grafana system metrics (load increasing from 50 to 500)
![Grafana during load (LA, CPU, RAM)](screenshots/grafana-system.png)
![Grafana during load (DISK)](screenshots/grafana-disk.png)

## Grafana Docker metrics
![Grafana during load (DOCKER)](screenshots/grafana-docker.png)

## Grafana Elastic Search metrics
![Grafana during load (Elastic Search)](screenshots/grafana-elastic.png)

## Grafana Mongo metrics
![Grafana during load (Mongo)](screenshots/grafana-mongo.png)

## Grafana NGINX metrics
![Grafana during load (Mongo)](screenshots/grafana-nginx.png)

## Load test results


## siege output with concurrency = 10
```
Transactions:                  89357 hits
Availability:                 100.00 %
Elapsed time:                  59.96 secs
Data transferred:               6.15 MB
Response time:                  0.01 secs
Transaction rate:            1490.28 trans/sec
Throughput:                     0.10 MB/sec
Concurrency:                    9.94
Successful transactions:       89357
Failed transactions:               0
Longest transaction:            0.09
Shortest transaction:           0.00
```

## siege output with concurrency = 25
```
Transactions:                 134914 hits
Availability:                 100.00 %
Elapsed time:                  59.32 secs
Data transferred:               9.29 MB
Response time:                  0.01 secs
Transaction rate:            2274.34 trans/sec
Throughput:                     0.16 MB/sec
Concurrency:                   24.87
Successful transactions:      134914
Failed transactions:               0
Longest transaction:            0.17
Shortest transaction:           0.00
```

## siege output with concurrency = 50
```
Transactions:                 176199 hits
Availability:                 100.00 %
Elapsed time:                  59.79 secs
Data transferred:              12.14 MB
Response time:                  0.02 secs
Transaction rate:            2946.96 trans/sec
Throughput:                     0.20 MB/sec
Concurrency:                   49.83
Successful transactions:      176199
Failed transactions:               0
Longest transaction:            0.17
Shortest transaction:           0.00
```

## siege output with concurrency = 100
```
Transactions:                 245789 hits
Availability:                 100.00 %
Elapsed time:                  59.02 secs
Data transferred:              16.93 MB
Response time:                  0.02 secs
Transaction rate:            4164.50 trans/sec
Throughput:                     0.29 MB/sec
Concurrency:                   99.73
Successful transactions:      245789
Failed transactions:               0
Longest transaction:            0.38
Shortest transaction:           0.00
```

## siege output with concurrency = 200
```
Transactions:                 274367 hits
Availability:                 100.00 %
Elapsed time:                  59.25 secs
Data transferred:              18.90 MB
Response time:                  0.04 secs
Transaction rate:            4630.67 trans/sec
Throughput:                     0.32 MB/sec
Concurrency:                  199.62
Successful transactions:      274367
Failed transactions:               0
Longest transaction:            0.99
Shortest transaction:           0.00
```

## siege output with concurrency = 300
```
Transactions:                 241992 hits
Availability:                 100.00 %
Elapsed time:                  59.12 secs
Data transferred:              16.68 MB
Response time:                  0.07 secs
Transaction rate:            4093.23 trans/sec
Throughput:                     0.28 MB/sec
Concurrency:                  299.46
Successful transactions:      241992
Failed transactions:               0
Longest transaction:            0.49
Shortest transaction:           0.00
```

## siege output with concurrency = 400
```
Transactions:                 234868 hits
Availability:                 100.00 %
Elapsed time:                  59.14 secs
Data transferred:              16.19 MB
Response time:                  0.10 secs
Transaction rate:            3971.39 trans/sec
Throughput:                     0.27 MB/sec
Concurrency:                  398.28
Successful transactions:      234868
Failed transactions:               0
Longest transaction:            0.74
Shortest transaction:           0.00
```

## siege output with concurrency = 500
```
Transactions:                 244874 hits
Availability:                 100.00 %
Elapsed time:                  59.47 secs
Data transferred:              16.88 MB
Response time:                  0.12 secs
Transaction rate:            4117.61 trans/sec
Throughput:                     0.28 MB/sec
Concurrency:                  498.57
Successful transactions:      244874
Failed transactions:               0
Longest transaction:            1.69
Shortest transaction:           0.00
```

## Summary
Throughput increases with concurrency increase. Increasing concurrency beyond 100 increases response time and keeps the throughput on the same level. The system consistently maintains 100% availability despite concurrency increase.

Even under the highest concurrency, idle CPU is above 20%, and used memory doesn't increase above 10.7 GB out of 15.3 total memory. 

It looks like there is a limit of open connections to Mongo - it never increases above 105. `MongoDefaults.MaxConnectionPoolSize` is equal to 100 for .NET MongoClient. It seems to be the bottleneck of the system.

Another bottleneck could be the number of threads in Elastic Search - it is always around 100 during the load. I tried running the same test with elastic search GET URL only and it decreased idle CPU to be between 12% to 17% and Elastic CPU usage to ~50%. There is a setting here `http://localhost:19200/_nodes/thread_pool?pretty` that limits the number of search requests to 100:

```
"search_throttled" : {
    "type" : "fixed_auto_queue_size",
    "size" : 1,
    "queue_size" : 100
}
```