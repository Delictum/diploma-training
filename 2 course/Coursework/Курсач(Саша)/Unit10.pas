unit Unit10;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.ComCtrls, Vcl.StdCtrls, Vcl.ExtCtrls;

type
  TForm10 = class(TForm)
    Timer1: TTimer;
    Label1: TLabel;
    ProgressBar1: TProgressBar;
    Label2: TLabel;
    Label3: TLabel;
    procedure Timer1Timer(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form10: TForm10;

implementation

{$R *.dfm}

uses Unit1;

procedure TForm10.Timer1Timer(Sender: TObject);
begin
  ProgressBar1.Position := ProgressBar1.Position + 15;
  if ProgressBar1.Position >= 100 then
  begin
    Form10.Hide;
    FormMain.Show;
    Timer1.Enabled := false;
  end;
end;

end.
