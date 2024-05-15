import asyncio
import websockets

# open index.html in browser after starting this

async def response(websocket, path):
    async for message in websocket:
        if (message != ""):
            await websocket.send("Your message: " + message) # sends back to client

async def main():
    async with websockets.serve(response, "localhost", 8888):
        await asyncio.Future() # runs forever

asyncio.run(main())