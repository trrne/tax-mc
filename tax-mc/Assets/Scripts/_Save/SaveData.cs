[System.Serializable]
public class SaveData
{
    public struct Datas
    {
        public (float, float) pos;
        public (float, float) cp;

        public Datas((float, float) _pos, (float, float) _cp)
        {
            this.pos = _pos;
            this.cp = _cp;
        }
    }
}