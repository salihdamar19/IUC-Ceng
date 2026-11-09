class Node:
    def __init__(self, newData):
        self.data = newData
        self.next = None

class LinkedList:
    def __init__(self):
        self.head = None

    def printList(self):
        if self.head is None:
            print("Liste bos")
            return
        current = self.head
        while current is not None:
            print(current.data, end=" ")
            current = current.next
        print()

    def insertLast(self, node):
        if self.head is None:
            self.head = node
        else:
            last = self.head
            while last.next is not None:
                last = last.next
            last.next = node

    def insertFirst(self, node):
        if node is not None:
            node.next = self.head
            self.head = node

    def insertAtIndex(self, idx, node):
        if idx <= 0:
            self.insertFirst(node)
        else:
            current = self.head
            for _ in range(1, idx):
                if current.next is not None:
                    current = current.next
            node.next = current.next
            current.next = node

    def insertSorted(self, node):
        if self.head is None:
            self.head = node
        else:
            if self.head.data > node.data:
                self.insertFirst(node)
            else:
                curr = self.head
                prev = None
                while curr is not None and node.data > curr.data:
                    prev = curr
                    curr = curr.next
                node.next = curr
                prev.next = node

    def removeLast(self):
        if self.head is not None:
            if self.head.next is None:
                self.head = None
            else:
                current = self.head
                while current.next is not None:
                    prev = current
                    current = current.next
                prev.next = None

    def removeFirst(self):
        if self.head is not None:
            self.head = self.head.next

    def removeAtIndex(self, idx):
        if idx < 0:
            self.removeFirst()
        else:
            current = self.head
            for _ in range(idx):
                if current is not None:
                    prev = current
                    current = current.next
            if current is None:
                self.removeLast()
            else:
                prev.next = current.next

    def removeByValue(self, value):
        if self.head is not None:
            if self.head.data == value:
                self.removeFirst()
            else:
                curr = self.head
                while curr is not None and value != curr.data:
                    prev = curr
                    curr = curr.next
                if curr is not None:
                    prev.next = curr.next


if __name__ == "__main__":
    linked_list = LinkedList()
    
    linked_list.insertLast(Node(10))
    linked_list.insertLast(Node(20))
    linked_list.insertLast(Node(30))
    linked_list.insertLast(Node(40))
    
    linked_list.insertFirst(Node(9))
    linked_list.insertFirst(Node(4))
    linked_list.insertFirst(Node(3))
    linked_list.insertFirst(None)

    linked_list.insertAtIndex(4, Node(15))
    linked_list.insertSorted(Node(5))

    linked_list.printList()

    linked_list.removeLast()
    linked_list.removeFirst()
    linked_list.removeAtIndex(15)
    linked_list.removeByValue(10)
    linked_list.removeByValue(4)
    linked_list.removeByValue(20)
    linked_list.removeByValue(40)
    
    linked_list.printList()