/*
* LSVRP C# Engine
* Script dedicated for Role-play server in Grand Theft Auto V game based on the external Multiplayer called Rage Multiplayer.
* @Author: Kubas (Jakub Skakuj)
* @StartDate: Jun 2018
*
* @urls:
* 		@RAGE-MP  	    https://rage.mp
* 		@LSVRP:			https://lsvrp.pl
*
* All Rights Reserved
* Copyright prohibited
*/
using System;

namespace LSVRP.Features.Dialogs
{
    /// <summary>
    /// Dane okna dialogowego
    /// </summary>
    [Serializable]
    public class DialogData
    {
        public DialogData(string text, object data)
        {
            Text = text;
            Data = data;
        }

        public string Text { get; set; }
        public object Data { get; set; }
    }

    [Serializable]
    public class DialogColumn
    {
        public DialogColumn(string name, int size)
        {
            Name = name;
            Size = size;
        }

        public int Size { get; set; }
        public string Name { get; set; }
    }

    [Serializable]
    public class DialogRow
    {
        public DialogRow(object data, string[] text)
        {
            if (data == null) data = "not-clickable";
            Data = data;
            Text = text;
        }

        public object Data { get; set; }
        public string[] Text { get; set; }
    }


    /// <summary>
    /// Dane okna modal
    /// </summary>
    [Serializable]
    public class ModalData
    {
        public ModalData(string first, string second)
        {
            First = first;
            Second = second;
        }

        public string First { get; set; }
        public string Second { get; set; }
    }
}