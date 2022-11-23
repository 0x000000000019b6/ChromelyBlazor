 
 # ChromelyBlazor

### Dotnet 7 x64:
```
wget https://download.visualstudio.microsoft.com/download/pr/253e5af8-41aa-48c6-86f1-39a51b44afdc/5bb2cb9380c5b1a7f0153e0a2775727b/dotnet-sdk-7.0.100-linux-x64.tar.gz
```
```
sudo mkdir /usr/bin/dotnet
```
```
sudo tar xzf dotnet-sdk-7.0.100-linux-x64.tar.gz -C /usr/bin/dotnet
```
```
echo 'export DOTNET_ROOT=/usr/bin/dotnet' >> ~/.bashrc
```
```
echo 'export PATH=$PATH:/usr/bin/dotnet' >> ~/.bashrc
```
```
sudo reboot
```

### Dotnet 7 arm:
```
wget https://download.visualstudio.microsoft.com/download/pr/47337472-c910-4815-9d9b-80e1a30fcf16/14847f6a51a6a7e53a859d4a17edc311/dotnet-sdk-7.0.100-linux-arm64.tar.gz
```
```
sudo mkdir /usr/bin/dotnet
```
```
sudo tar xzf dotnet-sdk-7.0.100-linux-arm64.tar.gz -C /usr/bin/dotnet
```
```
echo 'export DOTNET_ROOT=/usr/bin/dotnet' >> ~/.bashrc
```
```
echo 'export PATH=$PATH:/usr/bin/dotnet' >> ~/.bashrc
```
```
sudo reboot
```

### Publish x64:
```
dotnet publish -c Release -r linux-x64
```
### Publish arm:
```
dotnet publish -c Release -r linux-arm
```
