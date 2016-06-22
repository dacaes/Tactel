#region LICENSE
//==============================================================================//
//	Copyright (c) 2014-2016 Daniel Castaño Estrella						        //
//	This projected is licensed under the terms of the MIT license.				//
//	See accompanying file LICENSE or copy at http://opensource.org/licenses/MIT	//
//==============================================================================//
#endregion

using UnityEngine;

namespace Tactel.Extensions
{
    public static class Extensions
    {
        public static T[] CompactArray<T>(this T[] array)
        {
            int empty_cells_count = 0;
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] == null)
                    empty_cells_count++;
                else
                {
                    //there were empty cells
                    if(empty_cells_count > 0)
                    {
                        array[i - empty_cells_count] = array[i];    //copy object back
                        array[i] = default(T);    //delete duplicate object
                        i -= empty_cells_count;
                        empty_cells_count = 0;

                    }
                }
            }

            return array;
        }

        public static void SetBool(string name, bool value)
        {
            PlayerPrefs.SetInt(name, value ? 1 : 0);
        }

        public static bool GetBool(string name, bool defaultValue = false)
        {
            return PlayerPrefs.GetInt(name) == 1 ? true : defaultValue;
        }
    }
}