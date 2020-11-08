unit Unit6;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.ComCtrls, Vcl.ExtCtrls, Vcl.StdCtrls;

type
  TForm6 = class(TForm)
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Timer1: TTimer;
    ProgressBar1: TProgressBar;
    procedure Timer1Timer(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form6: TForm6;

implementation

{$R *.dfm}

uses Unit1;

procedure TForm6.Timer1Timer(Sender: TObject);
begin
  ProgressBar1.Position := ProgressBar1.Position + 15;
  if ProgressBar1.Position >= 100 then
    begin
      FormDinozavr.Show;
      Form6.Hide;
      Timer1.Enabled := false;
    end;
end;

end.
