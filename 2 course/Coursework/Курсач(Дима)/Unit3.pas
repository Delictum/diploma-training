unit Unit3;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.ComCtrls, Vcl.StdCtrls, Vcl.ExtCtrls;

type
  TForm3 = class(TForm)
    PageControl1: TPageControl;
    TabSheet1: TTabSheet;
    TabSheet2: TTabSheet;
    TabSheet3: TTabSheet;
    TabSheet4: TTabSheet;
    TabSheet5: TTabSheet;
    TabSheet6: TTabSheet;
    TabSheet7: TTabSheet;
    TabSheet8: TTabSheet;
    TabSheet9: TTabSheet;
    TabSheet10: TTabSheet;
    RadioGroup1: TRadioGroup;
    RadioGroup2: TRadioGroup;
    RadioGroup3: TRadioGroup;
    RadioGroup5: TRadioGroup;
    RadioGroup6: TRadioGroup;
    RadioGroup7: TRadioGroup;
    RadioGroup8: TRadioGroup;
    RadioGroup9: TRadioGroup;
    CheckBox1: TCheckBox;
    CheckBox2: TCheckBox;
    CheckBox3: TCheckBox;
    CheckBox4: TCheckBox;
    Label1: TLabel;
    Edit1: TEdit;
    Label2: TLabel;
    Button2: TButton;
    TabSheet11: TTabSheet;
    Label3: TLabel;
    Label4: TLabel;
    Image1: TImage;
    procedure Button2Click(Sender: TObject);
    procedure FormShow(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form3: TForm3;
    answers:array[0..10]of boolean;

implementation

{$R *.dfm}
var i,tru : integer;
tr : array [0..9] of boolean;

procedure TForm3.Button2Click(Sender: TObject);
var n : integer;
begin
i := PageControl1.ActivePageIndex;
  if PageControl1.ActivePageIndex < 10 then
  begin
  case i of
    0 : if RadioGroup1.ItemIndex = 1 then begin tr[0] := true end;
    1 : if (CheckBox3.Checked = false) and (CheckBox4.Checked = true) and (CheckBox1.Checked = false) and (CheckBox2.Checked = false)  then begin tr[1] := true end;
    2 : if RadioGroup2.ItemIndex = 3 then begin tr[2] := true end;
    3 : if RadioGroup3.ItemIndex = 0 then begin tr[3] := true end;
    4 : if Edit1.Text = '���������' then begin tr[4] := true end;
    5 : if RadioGroup5.ItemIndex = 2 then begin tr[5] := true end;
    6 : if RadioGroup6.ItemIndex = 2 then begin tr[6] := true end;
    7 : if RadioGroup8.ItemIndex = 1 then begin tr[7] := true end;
    8 : if RadioGroup9.ItemIndex = 0 then begin tr[8] := true end;
    9 : begin Button2.Caption := '�����';
    if RadioGroup7.ItemIndex = 2 then begin tr[9] := true end;
    for n := 0 to 9 do
      begin
        if tr[n] then
        tru := tru + 1;

      end;

        edit1.Text := inttostr(tru);
label3.Caption :='�� �������� ��������� �� ' + inttostr(tru)+' �� 10-�� ��������!';
    tru := 0;
    RadioGroup1.ItemIndex:=-1;
    RadioGroup2.ItemIndex:=-1;
    RadioGroup3.ItemIndex:=-1;
    RadioGroup5.ItemIndex:=-1;
    RadioGroup6.ItemIndex:=-1;
    RadioGroup7.ItemIndex:=-1;
    RadioGroup8.ItemIndex:=-1;
    RadioGroup9.ItemIndex:=-1;
    CheckBox1.Checked:=false;
    CheckBox3.Checked:=false;
    CheckBox2.Checked:=false;
    CheckBox4.Checked:=false;
    Edit1.Text:= '';
    tr[0] := false;
tr[1] := false;
tr[2] := false;
tr[3] := false;
tr[4] := false;
tr[5] := false;
tr[6] := false;
tr[7] := false;
tr[8] := false;
tr[9] := false;
    end;
    10 : form3.Close;
  end;
end;
  if PageControl1.ActivePage = TabSheet11 then
  form3.Hide;

  PageControl1.ActivePageIndex := PageControl1.ActivePageIndex + 1;
end;

procedure TForm3.FormShow(Sender: TObject);
begin
PageControl1.ActivePageIndex := 0;
tru:=0;
tr[0] := false;
tr[1] := false;
tr[2] := false;
tr[3] := false;
tr[4] := false;
tr[5] := false;
tr[6] := false;
tr[7] := false;
tr[8] := false;
tr[9] := false;
end;

end.
