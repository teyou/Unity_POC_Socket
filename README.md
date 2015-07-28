# Unity with Socket.IO Interaction
POC using web Socket to interact with Unity APP

Demo Video: https://vimeo.com/134721839

---

/Server/

- index.js : Server side node express code
- /public/index.html : The color controller using Socket.IO 



/Client/

This contains Unity3D code for showing the result (aka color), the user can change the color in realtime via index.html


---
Testing Server:

https://socketcolor.herokuapp.com/

For quick testing, can configure the Websocket Url to:

ws://socketcolor.herokuapp.com/socket.io/?EIO=4&transport=websocket

