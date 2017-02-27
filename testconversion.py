import unittest
from dollarsText import Money

class TestFactorial(unittest.TestCase):
    """
    Our basic test class
    """

    def test_ones(self):
        """
        The actual test.
        Any method which starts with ``test_`` will considered as a test case.
        """
        res = Money.ones('1')
        self.assertEqual(res, "One")

    def test_tens(self):
        res = Money.tens('20')
        self.assertEqual(res, "Twenty")



if __name__ == '__main__':
    unittest.main()
