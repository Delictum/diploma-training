program Project1;

uses
  Vcl.Forms,
  Unit1 in 'Unit1.pas' {FormProg},
  Unit3 in 'Unit3.pas' {Form3},
  Unit10 in 'Unit10.pas' {Form10},
  Unit2 in 'Unit2.pas' {Form2},
  Unit7 in 'Unit7.pas' {FormHelp},
  Unit4 in 'Unit4.pas' {Form4},
  Unit5 in 'Unit5.pas' {Form5},
  Unit6 in 'Unit6.pas' {Form6},
  Unit8 in 'Unit8.pas' {Form8},
  Unit9 in 'Unit9.pas' {FormNew};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm10, Form10);
  Application.CreateForm(TFormHelp, FormHelp);
  Application.CreateForm(TFormProg, FormProg);
  Application.CreateForm(TForm3, Form3);
  Application.CreateForm(TForm2, Form2);
  Application.CreateForm(TForm4, Form4);
  Application.CreateForm(TForm5, Form5);
  Application.CreateForm(TForm6, Form6);
  Application.CreateForm(TForm8, Form8);
  Application.CreateForm(TFormNew, FormNew);
  Application.Run;
end.
