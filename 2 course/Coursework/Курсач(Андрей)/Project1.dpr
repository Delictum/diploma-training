program Project1;

uses
  Vcl.Forms,
  Unit1 in 'Unit1.pas' {LogOut},
  Unit2 in 'Unit2.pas' {LogReg},
  Unit3 in 'Unit3.pas' {FormBegin},
  Unit4 in 'Unit4.pas' {FormGame},
  Unit5 in 'Unit5.pas' {FormEnd},
  Unit6 in 'Unit6.pas' {Form6},
  Unit10 in 'Unit10.pas' {Form10},
  Unit7 in 'Unit7.pas' {FormADMIN},
  Unit8 in 'Unit8.pas' {FormHelp};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm10, Form10);
  Application.CreateForm(TLogOut, LogOut);
  Application.CreateForm(TFormBegin, FormBegin);
  Application.CreateForm(TFormGame, FormGame);
  Application.CreateForm(TLogReg, LogReg);
  Application.CreateForm(TFormEnd, FormEnd);
  Application.CreateForm(TForm6, Form6);
  Application.CreateForm(TFormADMIN, FormADMIN);
  Application.CreateForm(TFormHelp, FormHelp);
  Application.Run;
end.
