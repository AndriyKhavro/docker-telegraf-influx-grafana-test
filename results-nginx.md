Start the app and monitoring:
```powershell
.\up.ps1
```

Run load testing:
```powershell
.\test.ps1
```

Turn off the app and monitoring:
```powershell
.\down.ps1
```

## test.ps1 output
```
Started load testing at 07/02/2023 17:03:45.
This is ApacheBench, Version 2.3 <$Revision: 1903618 $>
Copyright 1996 Adam Twiss, Zeus Technology Ltd, http://www.zeustech.net/
Licensed to The Apache Software Foundation, http://www.apache.org/

Benchmarking localhost (be patient)
Completed 5000 requests
Completed 10000 requests
Completed 15000 requests
Completed 20000 requests
Completed 25000 requests
Completed 30000 requests
Completed 35000 requests
Completed 40000 requests
Completed 45000 requests
Completed 50000 requests
Finished 50000 requests


Server Software:        nginx/1.25.1
Server Hostname:        localhost
Server Port:            5000

Document Path:          /api/products
Document Length:        113 bytes

Concurrency Level:      500
Time taken for tests:   87.515 seconds
Complete requests:      50000
Failed requests:        46408
   (Connect: 0, Receive: 0, Length: 46408, Exceptions: 0)
Non-2xx responses:      10631
Total transferred:      13437721 bytes
Total body sent:        9600000
HTML transferred:       6152673 bytes
Requests per second:    571.33 [#/sec] (mean)
Time per request:       875.153 [ms] (mean)
Time per request:       1.750 [ms] (mean, across all concurrent requests)
Transfer rate:          149.95 [Kbytes/sec] received
                        107.12 kb/s sent
                        257.07 kb/s total

Connection Times (ms)
              min  mean[+/-sd] median   max
Connect:        0    0   0.5      1      16
Processing:   342  852 166.8    841    2534
Waiting:      330  848 166.8    837    2533
Total:        342  852 166.8    841    2535
ERROR: The median and mean for the initial connection time are more than twice the standard
       deviation apart. These results are NOT reliable.

Percentage of the requests served within a certain time (ms)
  50%    841
  66%    908
  75%    953
  80%    982
  90%   1061
  95%   1129
  98%   1229
  99%   1351
 100%   2535 (longest request)
Finished POST at 07/02/2023 17:05:12
This is ApacheBench, Version 2.3 <$Revision: 1903618 $>
Copyright 1996 Adam Twiss, Zeus Technology Ltd, http://www.zeustech.net/
Licensed to The Apache Software Foundation, http://www.apache.org/

Benchmarking localhost (be patient)
Completed 5000 requests
Completed 10000 requests
Completed 15000 requests
Completed 20000 requests
Completed 25000 requests
Completed 30000 requests
Completed 35000 requests
Completed 40000 requests
Completed 45000 requests
Completed 50000 requests
Finished 50000 requests


Server Software:        nginx/1.25.1
Server Hostname:        localhost
Server Port:            5000

Document Path:          /api/products
Document Length:        86 bytes

Concurrency Level:      500
Time taken for tests:   92.674 seconds
Complete requests:      50000
Failed requests:        8780
   (Connect: 0, Receive: 0, Length: 8780, Exceptions: 0)
Non-2xx responses:      8780
Total transferred:      12193620 bytes
Total body sent:        12700000
HTML transferred:       4923380 bytes
Requests per second:    539.52 [#/sec] (mean)
Time per request:       926.745 [ms] (mean)
Time per request:       1.853 [ms] (mean, across all concurrent requests)
Transfer rate:          128.49 [Kbytes/sec] received
                        133.83 kb/s sent
                        262.32 kb/s total

Connection Times (ms)
              min  mean[+/-sd] median   max
Connect:        0    0   0.5      0       9
Processing:   140  917 242.9    868    2255
Waiting:      130  911 242.4    862    2251
Total:        140  918 243.0    868    2256

Percentage of the requests served within a certain time (ms)
  50%    868
  66%    975
  75%   1048
  80%   1096
  90%   1236
  95%   1382
  98%   1569
  99%   1717
 100%   2256 (longest request)
Finished PUT at 07/02/2023 17:06:45
This is ApacheBench, Version 2.3 <$Revision: 1903618 $>
Copyright 1996 Adam Twiss, Zeus Technology Ltd, http://www.zeustech.net/
Licensed to The Apache Software Foundation, http://www.apache.org/

Benchmarking localhost (be patient)
Completed 5000 requests
Completed 10000 requests
Completed 15000 requests
Completed 20000 requests
Completed 25000 requests
Completed 30000 requests
Completed 35000 requests
Completed 40000 requests
Completed 45000 requests
Completed 50000 requests
Finished 50000 requests


Server Software:        nginx/1.25.1
Server Hostname:        localhost
Server Port:            5000

Document Path:          /api/products/1234567890
Document Length:        0 bytes

Concurrency Level:      500
Time taken for tests:   79.518 seconds
Complete requests:      50000
Failed requests:        15987
   (Connect: 0, Receive: 0, Length: 15987, Exceptions: 0)
Non-2xx responses:      15987
Total transferred:      8511348 bytes
HTML transferred:       2509959 bytes
Requests per second:    628.79 [#/sec] (mean)
Time per request:       795.179 [ms] (mean)
Time per request:       1.590 [ms] (mean, across all concurrent requests)
Transfer rate:          104.53 [Kbytes/sec] received

Connection Times (ms)
              min  mean[+/-sd] median   max
Connect:        0    0   0.5      0       7
Processing:   191  790 177.1    769    2421
Waiting:       42  786 177.1    764    2419
Total:        192  791 177.1    769    2422

Percentage of the requests served within a certain time (ms)
  50%    769
  66%    840
  75%    892
  80%    920
  90%    995
  95%   1093
  98%   1269
  99%   1393
 100%   2422 (longest request)
Finished Get by ID (Mongo) at 07/02/2023 17:08:05
This is ApacheBench, Version 2.3 <$Revision: 1903618 $>
Copyright 1996 Adam Twiss, Zeus Technology Ltd, http://www.zeustech.net/
Licensed to The Apache Software Foundation, http://www.apache.org/

Benchmarking localhost (be patient)
Completed 5000 requests
Completed 10000 requests
Completed 15000 requests
Completed 20000 requests
Completed 25000 requests
Completed 30000 requests
Completed 35000 requests
Completed 40000 requests
Completed 45000 requests
Completed 50000 requests
Finished 50000 requests


Server Software:        nginx/1.25.1
Server Hostname:        localhost
Server Port:            5000

Document Path:          /api/products?query=phon
Document Length:        157 bytes

Concurrency Level:      500
Time taken for tests:   83.191 seconds
Complete requests:      50000
Failed requests:        34892
   (Connect: 0, Receive: 0, Length: 34892, Exceptions: 0)
Non-2xx responses:      15108
Total transferred:      50481568 bytes
HTML transferred:       43160704 bytes
Requests per second:    601.03 [#/sec] (mean)
Time per request:       831.907 [ms] (mean)
Time per request:       1.664 [ms] (mean, across all concurrent requests)
Transfer rate:          592.60 [Kbytes/sec] received

Connection Times (ms)
              min  mean[+/-sd] median   max
Connect:        0    0   0.5      0       5
Processing:   185  826 481.0    732    5720
Waiting:       18  822 481.0    728    5719
Total:        186  827 481.0    733    5720

Percentage of the requests served within a certain time (ms)
  50%    733
  66%    796
  75%    884
  80%    949
  90%   1046
  95%   1121
  98%   1241
  99%   4999
 100%   5720 (longest request)
Finished Get by query (Elastic) at 07/02/2023 17:09:28
Finished load testing. Start time 07/02/2023 17:03:45. End time 07/02/2023 17:09:28
```

## Grafana system metrics
![Grafana during load](screenshots/grafana-nginx.png)
## Grafana Docker metrics
![Grafana during load (DOCKER)](screenshots/grafana-nginx-docker.png)