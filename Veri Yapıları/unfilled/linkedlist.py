class Node:
    def __init__(self):
        self.data = None
        self.next = None
        self.prev = None

    def add(self, data):
        if self.data == None: #liste henuz bos mu
            self.data = data
            self.head = self
        elif self.next == None: #ben son eleman mıyım
            newnode = Node()
            newnode.data = data
            self.next = newnode
            newnode.prev = self
        else:
            self.next.add(data)

    def __str__(self):
        return str(self.data)

head = Node()
head.add(5)
head.add(10)
head.add(20)

print(head, head.next, head.next.prev, head.next.next, head.next.next.prev)