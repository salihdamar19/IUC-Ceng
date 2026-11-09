class Node:
    def __init__(self, data):
        self.data = data
        self.left = None
        self.right = None

class BST:
    def __init__(self):
        self.root = None

    def insert(self, data):
        self.root = self._insert(self.root, data)

    def _insert(self, node, data):
        if node is None:
            return Node(data)

        if data < node.data:
            node.left = self._insert(node.left, data)

        elif data > node.data:
            node.right = self._insert(node.right, data)

        return node

    def search(self, data):
        return self._search(self.root, data)

    def _search(self, node, data):
        if node is None:
            return False

        if node.data == data:
            return True

        if data < node.data:
            return self._search(node.left, data)

        else:
            return self._search(node.right, data)

    def delete(self, data):
        self.root = self._delete(self.root, data)

    def _delete(self, node, data):
        if node is None:
            return None

        if data < node.data:
            node.left = self._delete(node.left, data)

        elif data > node.data:
            node.right = self._delete(node.right, data)

        else:
            if node.left is None and node.right is None:
                return None
            elif node.left is None:
                return node.right
            elif node.right is None:
                return node.left
            else:
                successor = self._find_min(node.right)

                node.data = successor.data

                self._delete(node.right, successor.data)

    def _find_min(self, node):
        while node.left is not None:
            node = node.left

        return node









