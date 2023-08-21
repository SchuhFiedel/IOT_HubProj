# LAN Raspberry Pi Deployment

VS Studio / dotnet
- publish to arm (or arm 64 depending on OS)
- publish as Self Contained App (makes everything easier)

Copy the publish folder from your development machine to the RPi
- using [WinSCP](https://winscp.net/eng/download.php) for Windows Machines

Run your Program
- set rights:          chmod +x \<your app binary>
- execute the binary:       ./\<your app binary>

Set a static IP for the RPi 
- Add the mac address on your router / DHCP service

Install and setup nginx reverse proxy
- [nginx reverseproxy setup](https://engineerworkshop.com/blog/setup-an-nginx-reverse-proxy-on-a-raspberry-pi-or-any-other-debian-os/)

Add your domain name to etc/hosts file

Setup a DNS server on your RPi
- [https://pimylifeup.com/raspberry-pi-dns-server/](https://pimylifeup.com/raspberry-pi-dns-server/)
- [config file example](<[https://github.com/imp/dnsmasq/blob/master/dnsmasq.conf.example](https://github.com/imp/dnsmasq/blob/master/dnsmasq.conf.example)>)

Set Custom DNS on the devices on your local network that want to connect, or if possible on your Router/Modem. 

Connect to your new Website



