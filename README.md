# RSATool
The true RSA encrypt/decrypt tool(use private key and 3rd public key both!)

Most of C# RSA encrypt/decrypt tools from internet, use one private key for encrypt/decrypt both, that's wrong! So I wrote this tool for true encrypt/decrypt. It use the private key and the 3rd public key for encrypt/decrypt both.

真正的RSA加密解密工具，网络上的工具，都是用自己的私钥进行加密解密，完全不是非对称加密解密方法，真正的RSA，需要用到自己的私钥和别人的公钥进行加密，确保只有真正的人才可以解密。而直接用私钥进行加密解密的，需要把私钥也分发出去，这是不正确的！
