Uses CRT;
label Out;
const
  N = 3;
  
//������ � ������������.
//����������� ������ �������� ������ �� �������� �������, ������������ �� �����. 
//����� ������ ����� ������� ������� ����, ����� �������� ������� �� ���� �����. 
//�����, ����������� �� ���������� ������, ����� ����� �������� ����, 
//�� �������� ����������� �� ������ ���� �������� ����� ������ �� ������� � ����� ������������ � ��������� �����.


var
  C: array [1..N, 1..N] of word; 
  Tour, P: array [1..N] of word; 
  l, s: word;
  i, j, k, min, ind: byte;
  All: boolean;

begin
  ClrScr;
  {���� ������}
  WriteLn('������� ������� ���������:');
  for i := 1 To N Do
    for j := 1 To N Do 
    if i <> j then
      readln(c[i, j])
    else
      c[i, j] := 0;
  WriteLn('������� ���������:');  
  
  for i := 1 To N Do
  begin
    for j := 1 To N Do 
      Write(C[i, j], ' ');
    WriteLn;
  end;
  
  All := False; 
  l := MaxInt; 
  for i := 1 To N Do P[i] := i; 
  repeat
    
    s := 0;
    for i := 1 To N - 1 Do s := s + C[P[i], P[i + 1]];
    s := s + C[P[n], P[1]];
    if l > s Then
    begin
      Tour := P;
      l := s;
    end;
    for i := N DownTo 3 do
    begin
      if P[i] < P[i - 1] Then continue;
      min := N + 1;
      k := P[i - 1];
      for j := i To N Do 
        if (P[j] > k) and (P[j] < min) Then
        begin
          min := P[j];
          ind := j;
        end;
      P[i - 1] := min;
      P[ind] := k;
      for j := i To N - 1 Do
      begin
        min := N + 1;
        for k := j To N Do 
          if min > P[k] Then
          begin
            min := P[k];
            ind := k;
          end;
        k := P[j];
        P[j] := min;
        P[ind] := k;
      end;
      goto out;
    end;
    All := true;
    Out: 
  until All;
  {���� ��������� ��� ������������, �� ������ ����������� ���}
  Write('����������� ���: ');
  for i := 1 To N Do Write(Tour[i], '-');
  Write('1');
  WriteLn(' ����� ����� ', l);
  ReadKey;
end.