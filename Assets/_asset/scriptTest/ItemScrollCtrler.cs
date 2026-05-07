using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScrollCtrler : MonoBehaviour
{
    [SerializeField] GridLayoutGroup gridLayoutGroup;
    [SerializeField] internal int framesQuantity = 200;
    [SerializeField] int maxReveal = 25;
    [SerializeField] int framesEachRow = 5;
    [SerializeField] Transform frameContainer;
    [SerializeField] RectTransform headPad, talePad;
    [SerializeField] int startIndex;
    [SerializeField] int revealTo;
    internal List<EquipFrame> framesList;
    internal bool isAll = true;

    //[ContextMenu("addframes")]
    //public void SpawnFrame()
    //{
    //    framesList.Clear();
    //    for (int i = 0; i < framesQuantity; i++)
    //    {
    //        var aframe = Instantiate(framePrafab, frameContainer);
    //        aframe.gameObject.SetActive(false);
    //        framesList.Add(aframe);
    //    }
    //}

    //private void Start()
    //{
    //    AddPadding();
    //    RevealFirst25();
    //}
    int GetFrameQuantity()
    {
        if (isAll) return frameContainer.childCount;
        else return framesList.Count;
    }

    GameObject GetAnEquipFrame(int index)
    {
        if (isAll) return frameContainer.GetChild(index).gameObject;
        else return framesList[index].gameObject;
    }
    internal void RevealFirstFrames()
    {
        ResetRevealTo();
        for (int i = startIndex; i < revealTo; i++)
        {
            GetAnEquipFrame(i).SetActive(true);
        }
    }
    internal void ResetRevealTo()
    {
        int n;
        if (maxReveal > GetFrameQuantity())
        {
            n = GetFrameQuantity();
        }
        else
        {
            n = maxReveal;
        }
        revealTo = n;
        startIndex = 0;
    }
    internal void HideCurrentFrames()
    {
        //Debug.Log("s " + startIndex);
        //Debug.Log("s " + revealTo);
        for (int i = startIndex; i < revealTo; i++)
        {
            GetAnEquipFrame(i).SetActive(false);
            //Debug.Log("si " + i);
        }
    }
    public void SetPaddingsSize()
    {
        int Rows = Mathf.CeilToInt((float)framesQuantity / framesEachRow);
        int RevealRows = maxReveal / framesEachRow;
        int k = Rows - RevealRows;
        if (k < 0) k = 0;

        Vector2 headPadSize = headPad.sizeDelta;
        headPadSize.y = 0;
        headPad.sizeDelta = headPadSize;

        var a = gridLayoutGroup.cellSize.y;
        var b = gridLayoutGroup.spacing.y;

        Vector2 size = talePad.sizeDelta;
        size.y = (a + b) * k;
        talePad.sizeDelta = size;
    }

    public int GetPositionInList(Vector2 val)
    {
        int Rows = Mathf.CeilToInt((float)framesQuantity / framesEachRow);
        int RevealRows = maxReveal / framesEachRow;
        int k = Rows - RevealRows;
        if (k <= 0) return -1;

        int usingQuantity = framesQuantity - maxReveal;
        if (usingQuantity <= 0) return -1;

        if (val.y < 0) val.y = 0;
        if (val.y > 1) val.y = 1;
        val.y = Mathf.Abs(1 - val.y);

        int currentRow;
        if (val.y > 0.5f)
        {
            currentRow = Mathf.CeilToInt(k * val.y);
        }
        else
        {
            currentRow = Mathf.FloorToInt(k * val.y);
        }

        return currentRow * framesEachRow;
    }
    public void TestScroll(Vector2 val)
    {
        int newStartIndex = GetPositionInList(val);
        if (newStartIndex == -1)
        {
            return;
        }
        if (newStartIndex < 0) return;
        int newRevealTo = newStartIndex + maxReveal;

        if (newRevealTo > GetFrameQuantity()) newRevealTo = GetFrameQuantity();
        //int newStartIndex = GetPositionInList(val);
        //if (newStartIndex == -1)
        //{
        //    return;
        //}
        //if (newStartIndex < 0) return;
        //int newRevealTo = newStartIndex + maxReveal;

        //if (newRevealTo > framesList.Count) newRevealTo = framesList.Count;

        //dichxuong
        if (newStartIndex > startIndex)
        {
            if (newStartIndex - startIndex <= 25)
            {
                int n = newStartIndex - startIndex;

                for (int i = revealTo; i < newRevealTo; i++)
                {
                    GetAnEquipFrame(i).SetActive(true);
                }
                for (int i = startIndex; i < newStartIndex; i++)
                {
                    GetAnEquipFrame(i).SetActive(false);
                }
            }
            else
            {
                for (int i = newStartIndex; i < newRevealTo; i++)
                {
                    GetAnEquipFrame(i).SetActive(true);
                }
                for (int i = startIndex; i < revealTo; i++)
                {
                    GetAnEquipFrame(i).SetActive(false);
                }
            }
        }
        //if (newStartIndex > startIndex)
        //{
        //    if (newStartIndex - startIndex <= 25)
        //    {
        //        int n = newStartIndex - startIndex;

        //        for (int i = revealTo; i < newRevealTo; i++)
        //        {
        //            framesList[i].gameObject.SetActive(true);
        //        }
        //        for (int i = startIndex; i < newStartIndex; i++)
        //        {
        //            framesList[i].gameObject.SetActive(false);
        //        }
        //    }
        //    else
        //    {
        //        for (int i = newStartIndex; i < newRevealTo; i++)
        //        {
        //            framesList[i].gameObject.SetActive(true);
        //        }
        //        for (int i = startIndex; i < revealTo; i++)
        //        {
        //            framesList[i].gameObject.SetActive(false);
        //        }
        //    }
        //}

        //dichlen
        if (newStartIndex < startIndex)
        {
            if ((newStartIndex - startIndex) * (-1) <= 25)
            {
                for (int i = newRevealTo; i < revealTo; i++)
                {
                    GetAnEquipFrame(i).SetActive(false);
                }
                for (int i = newStartIndex; i < startIndex; i++)
                {
                    GetAnEquipFrame(i).SetActive(true);
                }
            }
            else
            {
                for (int i = newStartIndex; i < newRevealTo; i++)
                {
                    GetAnEquipFrame(i).SetActive(true);
                }
                for (int i = startIndex; i < revealTo; i++)
                {
                    GetAnEquipFrame(i).SetActive(false);
                }
            }
        }
        //}        if (newStartIndex < startIndex)
        //{
        //    if ((newStartIndex - startIndex) * (-1) <= 25)
        //    {
        //        for (int i = newRevealTo; i < revealTo; i++)
        //        {
        //            framesList[i].gameObject.SetActive(false);
        //        }
        //        for (int i = newStartIndex; i < startIndex; i++)
        //        {
        //            framesList[i].gameObject.SetActive(true);
        //        }
        //    }
        //    else
        //    {
        //        for (int i = newStartIndex; i < newRevealTo; i++)
        //        {
        //            framesList[i].gameObject.SetActive(true);
        //        }
        //        for (int i = startIndex; i < revealTo; i++)
        //        {
        //            framesList[i].gameObject.SetActive(false);
        //        }
        //    }
        //}

        int currentRow = Mathf.FloorToInt(startIndex / framesEachRow);
        int newRow = Mathf.FloorToInt(newStartIndex / framesEachRow);
        float padHeightChange = newRow - currentRow;

        var a = gridLayoutGroup.cellSize.y;
        var b = gridLayoutGroup.spacing.y;
        Vector2 sizea = headPad.sizeDelta;
        sizea.y += (a + b) * padHeightChange;
        headPad.sizeDelta = sizea;

        Vector2 sizeb = talePad.sizeDelta;
        sizeb.y -= (a + b) * padHeightChange;
        talePad.sizeDelta = sizeb;

        startIndex = newStartIndex;
        revealTo = newRevealTo;
    }
}
