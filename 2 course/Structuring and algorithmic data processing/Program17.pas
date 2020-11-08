label Back;

var
  C: array [1..5, 1..5] of word; 
  Tour, P: array [1..5] of word; 
  l, s: word;
  i, j, k, min, ind: byte;
  All: boolean;

begin
  C[1, 1] := 0;C[1, 2] := 3;C[1, 3] := 1;C[1, 4] := 2;C[1, 5] := 3;
  C[2, 1] := 8;C[2, 2] := 0;C[2, 3] := 3;C[2, 4] := 4;C[2, 5] := 3;
  C[3, 1] := 3;C[3, 2] := 1;C[3, 3] := 0;C[3, 4] := 6;C[3, 5] := 2;
  C[4, 1] := 1;C[4, 2] := 8;C[4, 3] := 9;C[4, 4] := 0;C[4, 5] := 4;
  C[5, 1] := 3;C[5, 2] := 7;C[5, 3] := 4;C[5, 4] := 1;C[5, 5] := 0;
  
  for i := 1 To 5 Do
  begin
    for j := 1 To 5 Do 
      Write(C[i, j], ' ');
    WriteLn;
  end;
  
  All := False; 
  l := MaxInt; 
  for i := 1 To 5 Do
    P[i] := i;
  
  repeat
    s := 0;
    for i := 1 To 4 Do
      s := s + C[P[i], P[i + 1]];
    s := s + C[P[5], P[1]];
    if l > s Then
    begin
      Tour := P;
      l := s;
    end;
    for i := 5 DownTo 3 do
    begin
      if P[i] < P[i - 1] Then
        continue;
      min := 6;
      k := P[i - 1];
      for j := i To 5 Do 
        if (P[j] > k) and (P[j] < min) Then
        begin
          min := P[j];
          ind := j;
        end;
      P[i - 1] := min;
      P[ind] := k;
      for j := i To 4 Do
      begin
        min := 6;
        for k := j To 5 Do 
          if min > P[k] Then
          begin
            min := P[k];
            ind := k;
          end;
        k := P[j];
        P[j] := min;
        P[ind] := k;
      end;
      goto Back;
    end;
    All := true;
    Back: 
  until All;

  Write('Кратчайший путь(');
  for i := 1 To 5 Do
    Write(Tour[i], '-');
  Write('1');
  WriteLn(') имеет длину ', l, '.');
  
end.