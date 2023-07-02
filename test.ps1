$concurrencyLevel = 500
$numberOfRequests = 50000
$port = 5000 # change to 5080 to test without nginx

$startDate = Get-Date
echo "Started load testing at $startDate."

ab -p test-files/create-product.json -T application/json -c $concurrencyLevel -n $numberOfRequests http://localhost:$port/api/products
$now = Get-Date
echo "Finished POST at $now"

ab -u test-files/update-product.json -T application/json -c $concurrencyLevel -n $numberOfRequests http://localhost:$port/api/products
$now = Get-Date
echo "Finished PUT at $now"

ab -c $concurrencyLevel -n $numberOfRequests http://localhost:$port/api/products/1234567890
$now = Get-Date
echo "Finished Get by ID (Mongo) at $now"

ab -c $concurrencyLevel -n $numberOfRequests http://localhost:$port/api/products?query=phon
$now = Get-Date
echo "Finished Get by query (Elastic) at $now"

echo "Finished load testing. Start time $startDate. End time $now"

