using UnityEngine;

public class Outcode
{
    public bool up, down, right, left;
    public Outcode(Vector2 v)
    {
        up = v.y > 1;
        down = v.y < -1;
        right = v.x > 1;
        left = v.x < -1;
    }

    public Outcode()
    {
        up = false;
        down = false;
        right = false;
        left = false;
    }
    public Outcode(bool u, bool d, bool r, bool l)
    {
        up = u;
        down = d;
        right = r;
        left = l;
    }
    public  Outcode(Outcode oc)
    {
        up = oc.up;
        down = oc.down;
        right = oc.right;
        left = oc.left;
    }
    public static Outcode operator+(Outcode O1, Outcode O2)
    {
        return new Outcode(O1.up || O2.up, O1.down || O2.down, O1.right || O2.right, O1.left || O2.left);
    }
    public static Outcode operator*(Outcode O1, Outcode O2)
    {
        return new Outcode(O1.up && O2.up, O1.down && O2.down, O1.right && O2.right, O1.left && O2.left);
    }
    public static bool operator==(Outcode O1, Outcode O2)
    { 
        return O1.up == O2.up && O1.down == O2.down && O1.right == O2.right && O1.left == O2.left;
    }
    public static bool operator !=(Outcode O1, Outcode O2)
    {
        return !(O1 == O2);
    }
   public void display()
    {
        string s = (up?"1":"0")+ (down?"1":"0")+(right?"1":"0")+(left?"1":"0");
        Debug.Log(s);

    }
}
