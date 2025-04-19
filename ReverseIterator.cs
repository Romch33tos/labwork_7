using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTree
{
  public class ReverseIterator<T> : IEnumerator<T> where T : IComparable<T>
  {
    private BinaryTreeNode<T> _current;
    private readonly BinaryTreeNode<T> _root;

    public ReverseIterator(BinaryTreeNode<T> root)
    {
      _root = root;
      Reset();
    }

    public T Current => _current.Value;

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
      if (_current == null)
      {
        _current = FindRightmost(_root);
        return _current != null;
      }

      _current = FindPrevious(_current);
      return _current != null;
    }

    private BinaryTreeNode<T> FindPrevious(BinaryTreeNode<T> node)
    {
      if (node.Left != null)
      {
        return FindRightmost(node.Left);
      }

      var parent = node.Parent;
      while (parent != null && node == parent.Left)
      {
        node = parent;
        parent = parent.Parent;
      }

      return parent;
    }

    private BinaryTreeNode<T> FindRightmost(BinaryTreeNode<T> node)
    {
      while (node?.Right != null)
      {
        node = node.Right;
      }
      
      return node;
    }

    public void Reset()
    {
      _current = null;
    }

    public void Dispose()
    {
    }
  }
}
