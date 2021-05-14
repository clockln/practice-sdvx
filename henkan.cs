using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using static System.Console;
using static System.Math;
 
public class Prob{
    static public int mod = 1000000007;
    static public string al = "abcdefghijklmnopqrstuvwxyz";
    public static void Main(){
        // 方針
        //
        var id = 495;
        for(int i=0;i<1000;i++){
        var s = rstr();
        var list = s.Split(',');
        //WriteLine(string.Join(" ",list));
        
        list[0] = list[0].Replace("\'","\\\'");
        list[13] = list[13].Replace("\'","\\\'");
        list[14] = list[14].Replace("\'","\\\'");
        for(int j=0;j<list.Length;j++){
            if(list[j] == "") list[j] = "0";
        }
        
        if(list[0][0] == '"' && list[0][list[0].Length-1] != '"'){
            list[0] += ',' + list[1];
            for(int k=1;k<list.Length-1;k++){
                list[k] = list[k+1];
            }
            list[0] = list[0].Replace("\"\"","||||");
            list[0] = list[0].Replace("\"","");
            list[0] = list[0].Replace("||||","\"");
        }else if(list[0][0] == '"'){
            list[0] = list[0].Replace("\"\"","||||");
            list[0] = list[0].Replace("\"","");
            list[0] = list[0].Replace("||||","\"");
        }
        
        if(list[13][0] == '"' && list[13][list[13].Length-1] != '"'){
            list[13] += ',' + list[14];
            for(int k=14;k<list.Length-1;k++){
                list[k] = list[k+1];
            }
            list[13] = list[13].Replace("\"\"","||||");
            list[13] = list[13].Replace("\"","");
            list[13] = list[13].Replace("||||","\"");
        }else if(list[13][0] == '"'){
            list[13] = list[13].Replace("\"\"","||||");
            list[13] = list[13].Replace("\"","");
            list[13] = list[13].Replace("||||","\"");
        }
        
        if(list[14][0] == '"' && list[14][list[14].Length-1] != '"'){
            list[14] += ',' + list[15];
            for(int k=15;k<list.Length-1;k++){
                list[k] = list[k+1];
            }
            list[14] = list[14].Replace("\"\"","||||");
            list[14] = list[14].Replace("\"","");
            list[14] = list[14].Replace("||||","\"");
        }else if(list[14][0] == '"'){
            list[14] = list[14].Replace("\"\"","||||");
            list[14] = list[14].Replace("\"","");
            list[14] = list[14].Replace("||||","\"");
        }
        
        Write("{");
        
        Write($"id: {id},");
        id++;
        Write($"title: '{list[0]}',");
        Write($"Ver: '{list[2]}',");
        Write($"Dif: '{list[3]}',");
        Write($"Notes: {list[4]},");
        Write($"CHIP: {list[5]},");
        Write($"LONG: {list[6]},");
        Write($"VOL: {list[7]},");
        Write($"MaxEX: {list[8]},");
        Write($"VDif: '{list[9]}',");
        Write($"VNotes: {list[10]},");
        Write($"NotesDiff: {list[11]},");
        if(list[12].IndexOf("-") >= 0){
            var tempbpm = list[12].Split('-');
            var bpmsa = int.Parse(tempbpm[1]) - int.Parse(tempbpm[0]);
            Write($"minBPM: {tempbpm[0]},");
            Write($"maxBPM: {tempbpm[1]},");
            Write($"BPMsa: {bpmsa},");
        }else{
            Write($"minBPM: {list[12]},");
            Write($"maxBPM: {list[12]},");
            Write($"BPMsa: 0,");
        }
        Write($"Artist: '{list[13]}',");
        Write($"Effecter: '{list[14]}',");
        Write($"Vertical: {list[17]},");
        Write($"L: {list[15]},");
        Write($"R: {list[16]},");
        Write($"time: '{list[18]}',");
        
        WriteLine("},");
        }
        
	
	
    }
    public static void swap(ref int a,ref int b){int temp = a;a= b;b = temp;}
    static void charswap(ref char a,ref char b){char temp = a;a= b;b = temp;}
    static int ncr(int n,int r){if(n<r)return 0;r = Min(r,n-r);long nn = 1;for(int i=n-r+1;i<=n;i++){nn = nn*i%mod;}long rr = 1;for(int i=1;i<=r;i++){rr = rr*i%mod;}rr = square((int)rr,mod-2);nn = nn * rr %mod;return (int)nn;}
    // a^b mod
    static int square(int a,int b){string binary = Convert.ToString(b,2);int bileng = binary.Length;long a_power = a;long value = 1;for(int i=bileng-1;i>=0;i--){if(binary[i] == '1'){value = value*a_power%mod;}a_power = a_power*a_power%mod;}return (int)value;}
    static int square2(int a,int b){long output = 1;var list = new List<long>();int sh = 1;long n = a;list.Add(a);while(sh < b){sh *= 2;n = n*n%mod;list.Add(n);}for(int i=list.Count-1;i>=0;i--){if(b > sh){b -= sh;sh /= 2;output = output*list[i]%mod;}}return (int)output;}
    //各種読取
    static string rstr()   { return ReadLine(); }
    static int    rint()   { return int.Parse(ReadLine()); }
    static long   rlong()  { return long.Parse(ReadLine()); }
    static double rdouble(){ return double.Parse(ReadLine()); }
    static string[] stra()   { return ReadLine().Split(' '); }
    static int[]    inta()   { return Array.ConvertAll(stra(),x => int.Parse(x)); }
    static long[]   longa()  { return Array.ConvertAll(stra(),x => long.Parse(x)); }
    static double[] doublea(){ return Array.ConvertAll(stra(),x => double.Parse(x)); }
    static char[] chara(){ string[] a=stra();string b="";for(int i=0;i<a.Length;i++){b+=a[i];}return b.ToCharArray();}
    static int[,] inta2(int num_array,int in_array){ int[,] int_array2 = new int[num_array,in_array]; for(int i=0;i<num_array;i++){ int[] temp_array = inta(); for(int j=0;j<in_array;j++){ int_array2[i,j] = temp_array[j]; } } return int_array2; }
    // -----------------------------
    static long GCD(long a,long b){ if(a < b){ long temp = a; a = b; b = temp; } if(a % b == 0){ return b; } else{ long temp = b; b = a%b; a = temp; return GCD(a,b); } }
    static long LCM(long a,long b){ return a * b / GCD(a,b); }
    static void WriteArray(int[,] a,int b,int c){for(int i=0;i<b;i++){for(int j=0;j<c;j++){if(j!=0) Write(" ");Write(a[i,j]);}WriteLine();}}
}

class NCR{
    private long _N;
    private long[] _R;
    private int _mod = 1000000007;
    private int leftn;
    
    public NCR(int a){
        leftn = a;
        _R = new long[a+1];
        
        _N = 1;
        for(int i=2;i<=a;i++){
            _N = (_N * i) %_mod;
        }
        
        _R[0] = 1;
        for(int i=1;i<=a;i++){
            _R[i] = (_R[i-1] * i) % _mod;
            _R[i-1] = this.Square((int)_R[i-1],_mod-2);
        }
        _R[a] = this.Square((int)_R[a],_mod-2);
    }
    
    public int Do(int r){
        if(leftn<r)return 0;
        if(leftn==r) return 1;
        return (int)(((_N * _R[r]) %_mod * _R[leftn-r]) %_mod);
    }
    
    public int Square(int a,int b){
        string binary = Convert.ToString(b,2);
        int bileng = binary.Length;
        long a_power = a;
        long value = 1;
        for(int i=bileng-1;i>=0;i--){
            if(binary[i] == '1'){
                value = value*a_power%_mod;
            }
            a_power = a_power*a_power%_mod;
        }
        return (int)value;
    }
}

class UnionFind{
    private int[] _unionfind;
    private int[] _unionfind_size;
    
    public UnionFind(int a){
        _unionfind = new int[a];
        _unionfind_size = new int[a];
        for(int i=0;i<a;i++){
            _unionfind[i] = i;
            _unionfind_size[i] = 1;
        }
    }
    
    public int Root(int x){
        if(_unionfind[x] == x) return x;
        return _unionfind[x] = Root(_unionfind[x]);
    }
    
    public void Unite(int a,int b){
        a = Root(a);
        b = Root(b);
        if(a == b) return;
        if(_unionfind_size[a] < _unionfind_size[b]){
            int temp = a;
            a = b;
            b = temp;
        }
        _unionfind[b] = a;
        _unionfind_size[a] += _unionfind_size[b];
    }
    
    public bool Same(int a,int b){
        return Root(a) == Root(b);
    }
    
    public int Size(int x){
        return _unionfind_size[Root(x)];
    }
}

class PriorityQueue{
    private List<int> _priorityqueue = new List<int>();
    
    public void Enqueue(int a){
        _priorityqueue.Add(a);
        int num = _priorityqueue.Count-1;
        while(true){
            if(num == 0) break;
            if(_priorityqueue[(num-1)/2] < _priorityqueue[num]){ //大小逆の時弄るとこ
                int temp = _priorityqueue[(num-1)/2];
                _priorityqueue[(num-1)/2] = _priorityqueue[num];
                _priorityqueue[num] = temp;
                num = (num-1)/2;
            }else{
                break;
            }
        }
    }
    
    public int Dequeue(){
        int re = _priorityqueue[0];
        int temp = _priorityqueue[0];
        _priorityqueue[0] = _priorityqueue[_priorityqueue.Count-1];
        _priorityqueue[_priorityqueue.Count-1] = temp;
        _priorityqueue.RemoveAt(_priorityqueue.Count-1);
        int num = 0;
        while(true){
            int swapnum = -1;
            if((num+1)*2 < _priorityqueue.Count){
                if(_priorityqueue[num*2+1] > _priorityqueue[(num+1)*2]){ //大小逆の時弄るとこ
                    swapnum = num*2+1;
                }else{
                    swapnum = (num+1)*2;
                }
            }else if(num*2+1 < _priorityqueue.Count){
                swapnum = num*2+1;
            }
            if(swapnum == -1) break;
            if(_priorityqueue[swapnum] > _priorityqueue[num]){ //大小逆の時弄るとこ
                temp = _priorityqueue[swapnum];
                _priorityqueue[swapnum] = _priorityqueue[num];
                _priorityqueue[num] = temp;
                num = swapnum;
            }else{
                break;
            }
        }
        return re;
    }
    
    public int Peek(){
        return _priorityqueue[0];
    }
    
    public int Count(){
        return _priorityqueue.Count;
    }
}
class PriorityQueue2{
    private List<int> _priorityqueue = new List<int>();
    private List<int> _accompany_info = new List<int>();
    
    public void Enqueue(int a,int b){
        _priorityqueue.Add(a);
        _accompany_info.Add(b);
        int num = _priorityqueue.Count-1;
        while(true){
            if(num == 0) break;
            if(_priorityqueue[(num-1)/2] > _priorityqueue[num]){ //大小逆の時弄るとこ
                int temp = _priorityqueue[(num-1)/2];
                  _priorityqueue[(num-1)/2] = _priorityqueue[num];
                  _priorityqueue[num] = temp;
                temp = _accompany_info[(num-1)/2];
                  _accompany_info[(num-1)/2] = _accompany_info[num];
                  _accompany_info[num] = temp;
                num = (num-1)/2;
            }else{
                break;
            }
        }
    }
    
    public int[] Dequeue(){
        var re = new int[]{_priorityqueue[0],_accompany_info[0]};
        var qcount = _priorityqueue.Count;
        var temp = _priorityqueue[0]; _priorityqueue[0] = _priorityqueue[qcount-1]; _priorityqueue[qcount-1] = temp;
        temp = _accompany_info[0]; _accompany_info[0] = _accompany_info[qcount-1]; _accompany_info[qcount-1] = temp;
        _priorityqueue.RemoveAt(qcount-1);
        _accompany_info.RemoveAt(qcount-1);
        int num = 0;
        while(true){
            int swapnum = -1;
            if((num+1)*2 < _priorityqueue.Count){
                if(_priorityqueue[num*2+1] < _priorityqueue[(num+1)*2]){ //大小逆の時弄るとこ
                    swapnum = num*2+1;
                }else{
                    swapnum = (num+1)*2;
                }
            }else if(num*2+1 < _priorityqueue.Count){
                swapnum = num*2+1;
            }
            if(swapnum == -1) break;
            if(_priorityqueue[swapnum] < _priorityqueue[num]){ //大小逆の時弄るとこ
                temp = _priorityqueue[swapnum];_priorityqueue[swapnum] = _priorityqueue[num];_priorityqueue[num] = temp;
                temp = _accompany_info[swapnum];_accompany_info[swapnum] = _accompany_info[num];_accompany_info[num] = temp;
                num = swapnum;
            }else{
                break;
            }
        }
        return re;
    }
    
    public int[] Peek(){
        var temp = new int[]{_priorityqueue[0],_accompany_info[0]};
        return temp;
    }
    
    public int Count(){
        return _priorityqueue.Count;
    }
}
class PriorityQueue3{
    private List<int> _priorityqueue = new List<int>();
    private List<int> _accompany_info = new List<int>();
    private List<int> _accompany_info2 = new List<int>();
    
    public void Enqueue(int a,int b,int c){
        _priorityqueue.Add(a);
        _accompany_info.Add(b);
        _accompany_info2.Add(c);
        int num = _priorityqueue.Count-1;
        while(true){
            if(num == 0) break;
            if(_priorityqueue[(num-1)/2] > _priorityqueue[num]){ //大小逆の時弄るとこ
                int temp = _priorityqueue[(num-1)/2];
                  _priorityqueue[(num-1)/2] = _priorityqueue[num];
                  _priorityqueue[num] = temp;
                temp = _accompany_info[(num-1)/2];
                  _accompany_info[(num-1)/2] = _accompany_info[num];
                  _accompany_info[num] = temp;
                  temp = _accompany_info2[(num-1)/2];
                  _accompany_info2[(num-1)/2] = _accompany_info2[num];
                  _accompany_info2[num] = temp;
                num = (num-1)/2;
            }else{
                break;
            }
        }
    }
    
    public int[] Dequeue(){
        var re = new int[]{_priorityqueue[0],_accompany_info[0],_accompany_info2[0]};
        var qcount = _priorityqueue.Count;
        var temp = _priorityqueue[0]; _priorityqueue[0] = _priorityqueue[qcount-1]; _priorityqueue[qcount-1] = temp;
        temp = _accompany_info[0]; _accompany_info[0] = _accompany_info[qcount-1]; _accompany_info[qcount-1] = temp;
        temp = _accompany_info2[0]; _accompany_info2[0] = _accompany_info2[qcount-1]; _accompany_info2[qcount-1] = temp;
        _priorityqueue.RemoveAt(qcount-1);
        _accompany_info.RemoveAt(qcount-1);
        _accompany_info2.RemoveAt(qcount-1);
        int num = 0;
        while(true){
            int swapnum = -1;
            if((num+1)*2 < _priorityqueue.Count){
                if(_priorityqueue[num*2+1] < _priorityqueue[(num+1)*2]){ //大小逆の時弄るとこ
                    swapnum = num*2+1;
                }else{
                    swapnum = (num+1)*2;
                }
            }else if(num*2+1 < _priorityqueue.Count){
                swapnum = num*2+1;
            }
            if(swapnum == -1) break;
            if(_priorityqueue[swapnum] < _priorityqueue[num]){ //大小逆の時弄るとこ
                temp = _priorityqueue[swapnum];_priorityqueue[swapnum] = _priorityqueue[num];_priorityqueue[num] = temp;
                temp = _accompany_info[swapnum];_accompany_info[swapnum] = _accompany_info[num];_accompany_info[num] = temp;
                temp = _accompany_info2[swapnum];_accompany_info2[swapnum] = _accompany_info2[num];_accompany_info2[num] = temp;
                num = swapnum;
            }else{
                break;
            }
        }
        return re;
    }
    
    public int[] Peek(){
        var temp = new int[]{_priorityqueue[0],_accompany_info[0],_accompany_info2[0]};
        return temp;
    }
    
    public int Count(){
        return _priorityqueue.Count;
    }
}

class Permutation{
    private int[] _permutation;
    private int _length;
    
    public Permutation(int a){
        _permutation = new int[a];
        for(int i=0;i<a;i++){
            _permutation[i] = i;
        }
        _length = a;
    }
    public int[] now(){
        return _permutation;
    }
    
    public bool next(){
        var upper = -1;
        for(int i=0;i<_length-1;i++){
            if(_permutation[i] < _permutation[i+1]) upper = i;
        }
        if(upper == -1){
            return false;
        }
        var bigger = -1;
        for(int i=upper;i<_length;i++){
            if(_permutation[upper] <= _permutation[i]) bigger = i;
        }
        var temp = _permutation[upper];
        _permutation[upper] = _permutation[bigger];
        _permutation[bigger] = temp;
        var list = new List<int>();
        upper++;
        for(int i=upper;i<_length;i++){
            list.Add(_permutation[i]);
        }
        list.Reverse();
        for(int i=upper;i<_length;i++){
            _permutation[i] = list[i-upper];
        }
        return true;
    }
    
    public void prev0(){
        Array.Reverse(_permutation);
    }
    
    public bool prev(){
        var lower = -1;
        for(int i=0;i<_length-1;i++){
            if(_permutation[i] > _permutation[i+1]) lower = i;
        }
        if(lower == -1){
            return false;
        }
        var smaller = -1;
        for(int i=lower;i<_length;i++){
            if(_permutation[lower] >= _permutation[i]) smaller = i;
        }
        var temp = _permutation[lower];
        _permutation[lower] = _permutation[smaller];
        _permutation[smaller] = temp;
        var list = new List<int>();
        lower++;
        for(int i=lower;i<_length;i++){
            list.Add(_permutation[i]);
        }
        list.Reverse();
        for(int i=lower;i<_length;i++){
            _permutation[i] = list[i-lower];
        }
        return true;
    }
}

class RMQ{
    private int[] _rmq;
    private int _number = -1;
    private int inf = 2147483647;
    
    public RMQ(int a){
        int n = 1;
        while(n < a) n*=2;
        _number = n-1;
        n = n*2-1;
        _rmq = new int[n];
    }
    
    public void Initialize(int a){
        for(int i=0;i<_rmq.Length;i++){
            _rmq[i] = a;
        }
    }
    
    public void Change(int num,int value){
        var changenum = _number + num;
        _rmq[changenum] = value;
        while(changenum > 0){
            changenum = (changenum-1)/2;
            _rmq[changenum] = Min(_rmq[changenum*2+1],_rmq[changenum*2+2]);
        }
    }
    
    public int Query(int a,int b){return act_query(a,++b,0,0,_number+1);}
    public int act_query(int a,int b,int k,int l,int r){
        if(b <= l || r <= a){
            return inf;
        }
        if(a <= l && r <= b){
            return _rmq[k];
        }
        int vl = act_query(a,b,k*2+1,l,(l+r)/2);
        int vr = act_query(a,b,k*2+2,(l+r)/2,r);
        return Min(vl,vr);
    }
}
class RMS{
    private int[] _rms;
    private int _number = -1;
    private int zero = 0;
    
    public RMS(int a){
        int n = 1;
        while(n < a) n*=2;
        _number = n-1;
        n = n*2-1;
        _rms = new int[n];
    }
    
    public void Change(int num,int value){
        var changenum = _number + num;
        _rms[changenum] = value;
        while(changenum > 0){
            changenum = (changenum-1)/2;
            _rms[changenum] = _rms[changenum*2+1] + _rms[changenum*2+2];
        }
    }
    
    public int Query(int a,int b){return act_query(a,++b,0,0,_number+1);}
    public int act_query(int a,int b,int k,int l,int r){
        if(b <= l || r <= a){
            return zero;
        }
        if(a <= l && r <= b){
            return _rms[k];
        }
        int vl = act_query(a,b,k*2+1,l,(l+r)/2);
        int vr = act_query(a,b,k*2+2,(l+r)/2,r);
        return vl + vr;
    }
    
    public void Check(){
        for(int i=0;i<_rms.Length;i++){
            WriteLine(_rms[i]);
        }
    }
}
class bitRMS{
    private int[] _rms;
    private int _number = -1;
    private int zero = 0;
    
    public bitRMS(int a){
        int n = 1;
        while(n < a) n*=2;
        _number = n-1;
        n = n*2-1;
        _rms = new int[n];
    }
    
    public void Change(int num,int value){
        var changenum = _number + num;
        _rms[changenum] = value;
        while(changenum > 0){
            changenum = (changenum-1)/2;
            _rms[changenum] = _rms[changenum*2+1] | _rms[changenum*2+2];
        }
    }
    
    public int Query(int a,int b){return act_query(a,++b,0,0,_number+1);}
    public int act_query(int a,int b,int k,int l,int r){
        if(b <= l || r <= a){
            return zero;
        }
        if(a <= l && r <= b){
            return _rms[k];
        }
        int vl = act_query(a,b,k*2+1,l,(l+r)/2);
        int vr = act_query(a,b,k*2+2,(l+r)/2,r);
        return vl | vr;
    }
    
    public void Check(){
        for(int i=0;i<_rms.Length;i++){
            WriteLine(_rms[i]);
        }
    }
}

class BIT{
    private long[] _bit;
    private int leng;
    
    public BIT(int a){
        _bit = new long[a+1];
        leng = _bit.Length;
    }
    
    public void Change(int a,long b){
        while(a <= leng){
            _bit[a] += b;
            a += -a & a;
        }
    }
    
    public long Query(int a,int b){
        a--;
        long ret = 0;
        while(b > 0){
            ret += _bit[b];
            b -= -b & b;
        }
        while(a > 0){
            ret -= _bit[a];
            a -= -a & a;
        }
        return ret;
    }
}

class Matrixsquare{
    private long[,] _matrix;
    private long[,] _E;
    private int _mod = 1000000007;
    
    public Matrixsquare(int a,long[,] b){
        _matrix = new long[a,a];
        _E = new long[a,a];
        for(int i=0;i<a;i++){
            _E[i,i] = 1;
        }
        Array.Copy(b,_matrix,b.Length);
    }
    
    public long[,] IterativeSquare(int a){
        while(a > 0){
            if(a %2 == 1){
                _E = MultiMatrix(_E,_matrix);
            }
            a = a>>1;
            _matrix = MultiMatrix(_matrix,_matrix);
        }
        return _E;
    }
    
    public long[,] MultiMatrix(long[,] a,long[,] b){
        var m = a.GetLength(0);
        var ret = new long[m,m];
        for(int i=0;i<m;i++){
            for(int j=0;j<m;j++){
                for(int k=0;k<m;k++){
                    ret[i,j] += a[k,j]*b[i,k];
                }
                ret[i,j] %= _mod;
            }
        }
        return ret;
    }
}
