using System;
namespace List
{
  public class ArrayList
  {
    public int Length { get; private set; }
    public int Capacity => _array.Length; 
    private int[] _array;

    public ArrayList()
    {
      Length = 0; // почему это называется длинной, если длину при иницилизации мы сами ниже задали 
            _array = new int[10];
    }
    public ArrayList(int value)
    {
        Length = 1;
        _array = new int[10];
        _array[0] = value;
    }

    public ArrayList(int[] vs)
    {
      _array = new int[vs.Length];
     for(int i =0; i < _array.Length; i++)
      {
        _array[i] = vs[i];
      }
      
      Length = vs.Length;
      
    }
    public int this[int index]
    {
            
      get
      {
                if(index> Length)
                {
                    throw new ArgumentOutOfRangeException("Индекс вне массива");
                }
        return _array[index];
      }

      set
      {
                if (index > Length && index < 0 )
                {
                    throw new ArgumentOutOfRangeException("Индекс вне массива");
                }
                
                _array[index] = value;
      }
    }

    public void Add(int value)
    {
      if (Length == _array.Length)
      {
        UpSize();
      }
      _array[Length] = value;
      Length++;
    }
    public void RemoveByIndex(int index)
    {
      ShiftToLeft(index);
      Length--;
      DownSize();
    }

    public void AddByZeroIndex(int value)
    {
      AddByIndex(0, value);
    }

    public void AddByIndex(int index, int value)
    {
      
      
        UpSize();
      

      for(int i =0; i < Length; i++)
      {
        if (i == index)
        {
          ShiftToRight(index);
          _array[index] = value;
          Length++;
        }
      }
    }

    public void ClearLastX( int startIndex)
    {
      for(int  i = startIndex; i > 0; i--)
      {
           RemoveByIndex(Length - 1);
      }
    }
    public int arrayLength()
    {
        return Length;
    }

    public int FirstIndexByValue(int value)
    { 
        for (int i = 0; i < Length; i++)
        {
            if(_array[i] == value)
            {
                return i;
            } 
        }
        return  -1;
    }

    public void ChangeValueByIndex(int index, int value)
        {
            _array[index] = value;
        }

    public void Reverse()
        {
            
            int tmpValue = 0;
                for (int i = 0; i < Length/2; i++)
                {
                tmpValue = _array[i];
                _array[i] = _array[ Length-1 - i];
                _array[ Length -1  - i] = tmpValue;
                }
            
        }

    public int MaxValue()
        {
            int maxValue = _array[0];

            for (int i = 0; i < Length; i++)
            {
                if(_array[i] > maxValue)
                {
                    maxValue = _array[i];
                }
            }
            return maxValue;
        }
        public int MinValue()
        {
            int minValue = _array[0];

            for (int i = 0; i < Length; i++)
            {
                if (_array[i] < minValue)
                {
                    minValue = _array[i];
                }
            }

            return minValue;
        }

        public int IndexOfMaxValue()
        {
            int indexOfMaxValue = 0;
           
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] > _array[indexOfMaxValue])
                {
                    indexOfMaxValue = i;
                }
            }

            return indexOfMaxValue;
        }
        public int IndexOfMinValue()
        {
            int indexOfMinValue = 0;

            for (int i = 0; i < Length; i++)
            {
                if (_array[i] < _array[indexOfMinValue])
                {
                    indexOfMinValue = i;
                }
            }

            return indexOfMinValue;
        }
        
        public void SortAscending()
        {
            for (int i = 1; i < Length; i++)
            {
                for (int j = 0; j < Length - i; j++)
                {
                    int tmp;

                    if (_array[j + 1] < _array[j])
                    {
                        tmp = _array[j];
                        _array[j] = _array[j + 1];
                        _array[j + 1] = tmp;
                    }
                }
            }
        }

        public void SortDescending()
        {
            for (int i = 1; i < Length; i++)
            {
                for (int j = 0; j < Length - i; j++)
                {
                    int tmp;

                    if (_array[j + 1] > _array[j])
                    {
                        tmp = _array[j];
                        _array[j] = _array[j + 1];
                        _array[j + 1] = tmp;
                    }
                }
            }
        }
        public int RemoveByValueFisrt(int value)
        {
            int index;

            for (int i = 0; i < Length; i++)
            {
                if(value == _array[i])
                {
                    index = i;
                    ShiftToLeft(i);
                    Length--;
                    return index;
                }
            }

            return -1;
        }

        public int RemoveByValueAll(int value)
        {
            int count = 0;
            while (RemoveByValueFisrt(value) != -1)
            {
                count++;

            }
            
            return count;
        }

        public void AddArrayInEnd(int [] insertArray)
        {
            UpSize(insertArray.Length);

            for (int i = Length-1; i < Length-1+ insertArray.Length; i++)
            {
                _array[i] = insertArray[i - Length - 1 ];
              
            }
            Length+=insertArray.Length;

        }



        //private void UpSize()
        //{
        //    if (Length + 1 > _array.Length) 
        //    {
        //    int newLength = (int)(_array.Length * 1.33d + 1);
        //    ChangeArraySize(newLength);
        //    }
        //}
        private void UpSize(int value = 1)
        {
            if (Length + value > _array.Length)
            {
                
                int newLength = (int)((_array.Length + value ) * 1.33d + 1);
                //Length += value;//Вопрос к Стасу , нужно ли это тут 
                ChangeArraySize(newLength);
            }
        }

        private void DownSize()
    {
      if (Length * 1.33 + 1 < _array.Length)
      {
        int newLength = (int)(_array.Length * 0.67d);

        ChangeArraySize(newLength);
      }
    }
    private void ShiftToRight(int index = 0, int step = 1)
    {

      for (int i = Length; i > index; i--)
      {
        _array[i] = _array[i - step];
      }
    }
    private void ShiftToLeft(int index = 0)
    {
      for (int i = index; i < Length - 1; i++)
      {
        _array[i] = _array[i + 1];

      }
      _array[Length - 1] = 0;
    }

    private void ChangeArraySize(int newLength)
    {
      int[] tmpArray = new int[newLength];

      for (int i = 0; i < Length; i++)
      {
        tmpArray[i] = _array[i];
      }

      _array = tmpArray;
    }

    public override string ToString()
    {
      string s = "";
      for (int i = 0; i < Length; i++)
      {
        s += _array[i] + " ";
      }
      return s;

    }
    public override bool Equals(object obj)
    {
      ArrayList arrayList = (ArrayList)obj;

      if (Length != arrayList.Length)
      {
        return false;
      }
      for (int i = 0; i < Length; i++)
      {
        if (_array[i] != arrayList[i])
        {
          return false;
        }
      }
      return true;
    }



  }


}
