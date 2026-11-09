class Node:
    def __init__(self, data):
        self.data = data
        self.next = None
        self.prev = None

class LinkedList:
    def __init__(self):
        self.head = None

    def append(self, data):
        new_node = Node(data)

        if self.head == None:
            self.head = new_node
            new_node.next = self.head
            new_node.prev = self.head
            return

        tail = self.head.prev

        tail.next = new_node
        new_node.prev = tail

        new_node.next = self.head
        self.head.prev = new_node

    def delete(self, data):
        if self.head == None:
            return

        current = self.head

        while True:
            #Silmek istediğimiz elemana geldik
            if current.data == data:

                #Liste tek elemandan oluşuyorsa
                if current.next == current:
                    self.head = None
                    return

                #Bağlantıları güncelledik
                current.prev.next = current.next
                current.next.prev = current.prev

                if current == self.head:
                    self.head = current.next

                return

            else:
                current = current.next

                if current == self.head:
                    break

    def search(self, data):
        current = self.head
        while current.next != self.head:
            if current.data == data:
                return True
            else:
                current = current.next
        return False

    def display(self):
        current = self.head
        while current.next != self.head:
            print(current.data, end=" <-> ")
            current = current.next
        print(current.data, end=" <-> ")
        print("\n")

ll = LinkedList()
ll.append(5)
ll.append(3)
ll.append(1)
ll.append(4)
ll.append(8)
ll.display()
print(ll.head.next.next.data)
print(ll.head.prev.prev.prev.data)
ll.delete(4)
print(ll.head.prev.prev.data)