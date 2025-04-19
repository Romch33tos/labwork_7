using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTree
{
  public class ForwardIterator<T> : IEnumerator<T> where T : IComparable<T>
  {
    private BinaryTreeNode<T> _current;
    private BinaryTreeNode<T> _root;

    public ForwardIterator(BinaryTreeNode<T> root)
    {
      _root = root;
      _current = null;
    }

    public T Current => _current.Value;

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
      if (_current == null)
      {
        _current = FindLeftmost(_root);
        return _current != null;
      }
      _current = Next(_current);
      return _current != null;
    }

    private BinaryTreeNode<T> Next(BinaryTreeNode<T> node)
    {
      if (node.Right != null)
      {
        return FindLeftmost(node.Right);
      }

      while (node.Parent != null && node == node.Parent.Right)
      {
        node = node.Parent;
      }

      return node.Parent;
    }

    private BinaryTreeNode<T> FindLeftmost(BinaryTreeNode<T> node)
    {
      while (node?.Left != null)
      {
        node = node.Left;
      }
      
      return node;
    }

    public void Reset()
    {
      _current = null;
    }

    public void Dispose() { }
  }
}
