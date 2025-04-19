using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTree
{
  public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
  {
    private BinaryTreeNode<T> _root;

    public delegate void TreeTraversalDelegate(T value);

    public void Add(T value)
    {
      _root = AddRecursive(_root, null, value);
    }

    private BinaryTreeNode<T> AddRecursive(BinaryTreeNode<T> node, BinaryTreeNode<T> parent, T value)
    {
      if (node == null)
      {
        return new BinaryTreeNode<T>(value) { Parent = parent };
      }

      if (value.CompareTo(node.Value) < 0)
      {
        node.Left = AddRecursive(node.Left, node, value);
      }
      else if (value.CompareTo(node.Value) > 0)
      {
        node.Right = AddRecursive(node.Right, node, value);
      }

      return node;
    }

    public void InOrderTraversal(TreeTraversalDelegate action)
    {
      if (action == null)
      {
        return;
      }

      Action<BinaryTreeNode<T>> traverse = null;
      traverse = (node) =>
      {
        if (node == null) 
        {
          return;
        }
        traverse(node.Left);
        action(node.Value);
        traverse(node.Right);
      };

      traverse(_root);
    }

    public IEnumerator<T> GetEnumerator()
    {
      return new ForwardIterator<T>(_root);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerable<T> GetReverseEnumerator()
    {
      return new ReverseEnumerable<T>(_root);
    }

    private class ReverseEnumerable<TNode> : IEnumerable<TNode> where TNode : IComparable<TNode>
    {
      private readonly BinaryTreeNode<TNode> _root;

      public ReverseEnumerable(BinaryTreeNode<TNode> root)
      {
        _root = root;
      }

      public IEnumerator<TNode> GetEnumerator()
      {
        return new ReverseIterator<TNode>(_root);
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
        return GetEnumerator();
      }
    }
  }

  public class BinaryTreeNode<T> where T : IComparable<T>
  {
    public T Value { get; set; }
    public BinaryTreeNode<T> Left { get; set; }
    public BinaryTreeNode<T> Right { get; set; }
    public BinaryTreeNode<T> Parent { get; set; }

    public BinaryTreeNode(T value)
    {
      Value = value;
      Left = null;
      Right = null;
      Parent = null;
    }
  }
}
