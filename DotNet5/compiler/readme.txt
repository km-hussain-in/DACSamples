INSTALLATION

  Windows
    copy dotnet-csc.cmd %USERPROFILE%\.dotnet\tools

  Linux/macOS
    cp dotnet-csc $HOME/.dotnet/tools
    chmod +x $HOME/.dotnet/tools/dotnet-csc
    export PATH=$PATH:$HOME/.dotnet/tools


USAGE

  dotnet csc yourlib.cs -t:library
  dotnet csc yourprog.cs -r:yourlib.dll
  dotnet yourprog.exe




  

