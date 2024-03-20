class Subscriber:
    def __init__(self, id, events, return_url):
        self.id = id
        self.events = events
        self.return_url = return_url