using System;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaManagement
{
    public partial class CustomList<Type>
    {
        private int _count;
        private int _capacity;
        public int Count{get {return _count;}}
        public int Capacity{get{return _capacity;}}
        public Type this[int index]
        {
            get{return _array[index];}
            set{_array[index]=value;}
        }
        private Type [] _array;
        public CustomList()
        {
            _count=0;
            _capacity=4;
            _array=new Type[_capacity];
        }
        public CustomList(int size)
        {
            _count=0;
            _capacity=size;
            _array=new Type[_capacity];
        }
        public void Add(Type element)
        {
            if(_count==_capacity)
            {
                GrowSize();
            }
            _array[_count]=element;
            _count++;
        }
        void GrowSize()
        {
            _capacity=_capacity*2;
            Type [] temp=new Type[_capacity];
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];
            }
            _array=temp;
        }
        public void AddRange(CustomList<Type> element)
        {
            _capacity=_count+element.Count+4;
            Type [] temp=new Type[_capacity];
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];
            }
            int k=0;
            for(int i=_count;i<_count+element.Count;i++)
            {
                temp[i]=element[k];
                k++;
            }
            _array=temp;
            _count=_count+element.Count;
        }

        
    }
}