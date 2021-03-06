﻿using System;
using System.Text;
namespace Array
{
    public class Array<E>
    {

        private E[] data;
        private int size;

        //索引器
        public E this[int index]
        {
            get { return get(index); }
            set { set(index, value); }
        }

        public Array(E[] array)
        {
            data = new E[array.Length];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = array[i];
            }

            size = data.Length;
        }

        // 构造函数，传入数组的容量capacity构造Array
        public Array(int capacity)
        {
            data = new E[capacity];
            size = 0;
        }

        // 无参数的构造函数，默认数组的容量capacity=10
        public Array()
        {
            data = new E[10];
        }

        // 获取数组的容量
        public int getCapacity()
        {
            return data.Length;
        }

        // 获取数组中的元素个数
        public int getSize()
        {
            return size;
        }

        // 返回数组是否为空
        public bool isEmpty()
        {
            return size == 0;
        }

        // 在index索引的位置插入一个新元素e
        public void add(int index, E e)
        {

            if (index < 0 || index > size)
                throw new IndexOutOfRangeException("Add failed. Require index >= 0 and index <= size.");

            if (size == data.Length)
                resize(2 * data.Length);

            for (int i = size - 1; i >= index; i--)
                data[i + 1] = data[i];

            data[index] = e;

            size++;
        }

        // 向所有元素后添加一个新元素
        public void addLast(E e)
        {
            add(size, e);
        }

        // 在所有元素前添加一个新元素
        public void addFirst(E e)
        {
            add(0, e);
        }

        // 获取index索引位置的元素
        public E get(int index)
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException("Get failed. Index is illegal.");
            return data[index];
        }

        // 修改index索引位置的元素为e
        public void set(int index, E e)
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException("Set failed. Index is illegal.");
            data[index] = e;
        }

        // 查找数组中是否有元素e
        public bool contains(E e)
        {
            for (int i = 0; i < size; i++)
            {
                if (data[i].Equals(e))
                    return true;
            }
            return false;
        }

        // 查找数组中元素e所在的索引，如果不存在元素e，则返回-1
        public int find(E e)
        {
            for (int i = 0; i < size; i++)
            {
                if (data[i].Equals(e))
                    return i;
            }
            return -1;
        }

        // 从数组中删除index位置的元素, 返回删除的元素
        public E remove(int index)
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException("Remove failed. Index is illegal.");

            E ret = data[index];
            for (int i = index + 1; i < size; i++)
                data[i - 1] = data[i];
            size--;
            data[size] = default(E); // loitering objects != memory leak

            if (size == data.Length / 4 && data.Length / 2 != 0)
                resize(data.Length / 2);
            return ret;
        }

        // 从数组中删除第一个元素, 返回删除的元素
        public E removeFirst()
        {
            return remove(0);
        }

        // 从数组中删除最后一个元素, 返回删除的元素
        public E removeLast()
        {
            return remove(size - 1);
        }

        // 从数组中删除元素e
        public void removeElement(E e)
        {
            int index = find(e);
            if (index != -1)
                remove(index);
        }

        //交换两个元素
        public void Swap(int i, int j)
        {
            if (i<0 || i>=size || j<0 || j>= size)
            {
                throw new Exception("i or j is illegal index.");
            }

            E e = this[i];
            this[i] = this[j];
            this[j] = e;

        }

        public override String ToString()
        {

            StringBuilder res = new StringBuilder();
            res.Append(String.Format("Array: size = {0} , capacity = {1}\n", size, data.Length));
            res.Append('[');
            for (int i = 0; i < size; i++)
            {
                res.Append(data[i]);
                if (i != size - 1)
                    res.Append(", ");
            }
            res.Append(']');
            return res.ToString();
        }

        // 将数组空间的容量变成newCapacity大小
        private void resize(int newCapacity)
        {

            E[] newData = new E[newCapacity];
            for (int i = 0; i < size; i++)
                newData[i] = data[i];
            data = newData;
        }
    }

}

