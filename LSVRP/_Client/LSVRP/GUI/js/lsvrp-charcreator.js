var lsvrpVueCharCreator = new Vue({
    el: "#lsvrp_charcreator",
    data: {
        show: false,
        activerow: 0,
        rows: JSON.parse(JSON.stringify(CREATOR_DATA_FULL)),
        sex: SEX_MALE,
        creatorType: CREATOR_TYPE_FULL,
        grid: {
            show: false,
            mouseClicked: false
        },
        colorChoose: false
    },
    methods: {
        VerticalKey: function(isUp) {
            if (!this.show) return;
            let lastChange = "down";
            if (isUp) {
                if (this.activerow - 1 < 0) return;
                lastChange = "up";
                this.activerow--;
            } else {
                if (this.rows[this.activerow + 1] === undefined) return;
                this.activerow++;
            }

            this.colorChoose = false;

            $(".lsvrp-charcreator .body").scrollTop(0);
            let scrollData = $(".lsvrp-charcreator .body .row.active").position().top +
                20 -
                $(".lsvrp-charcreator .body").height() +
                (lastChange === "up" ? -60 : 20);
            if (scrollData > 0) $(".lsvrp-charcreator .body").scrollTop(scrollData);

            if (this.rows[this.activerow].Type === TYPE_CUSTOM) {
                this.SetGridPoint(this.rows[this.activerow].Value);
                this.grid.show = true;
            } else this.grid.show = false;

        },
        HorizontalKey: function(isLeft) {
            if (!this.show) return;
            if (this.rows[this.activerow] === undefined) return;
            if (this.rows[this.activerow].Type !== TYPE_STANDARD &&
                this.rows[this.activerow].Type !== TYPE_STANDARD_SEX &&
                this.rows[this.activerow].Type !== TYPE_STANDARD_BINCO &&
                this.rows[this.activerow].Type !== TYPE_TOP_BINCO) return;

            if (this.rows[this.activerow].Type === TYPE_STANDARD) {
                if (isLeft) {
                    if (!this.colorChoose) {
                        if (this.rows[this.activerow].Active - 1 < 0) return;
                        this.rows[this.activerow].Active--;
                    } else {
                        if (this.rows[this.activerow].Color <= 0) return;
                        this.rows[this.activerow].Color--;
                    }


                } else {

                    if (!this.colorChoose) {
                        let aRow = this.rows[this.activerow];
                        if (aRow.Datas[aRow.Active + 1] === undefined) return;
                        aRow.Active++;
                    } else {
                        this.rows[this.activerow].Color++;
                    }

                }
            } else if (this.rows[this.activerow].Type === TYPE_STANDARD_SEX) {
                if (isLeft) {
                    if (!this.colorChoose) {
                        if (this.rows[this.activerow].Active - 1 < 0) return;
                        this.rows[this.activerow].Active--;
                    } else {
                        if (this.rows[this.activerow].Color <= 0) return;
                        this.rows[this.activerow].Color--;
                    }
                } else {

                    if (!this.colorChoose) {
                        let aRow = this.rows[this.activerow];
                        if (aRow.Datas[this.sex][aRow.Active + 1] === undefined) return;
                        aRow.Active++;
                    } else {
                        this.rows[this.activerow].Color++;
                    }
                }
            } else if (this.rows[this.activerow].Type === TYPE_STANDARD_BINCO) {
                if (isLeft) {
                    if (!this.colorChoose) {
                        if (this.rows[this.activerow].Active - 1 < 0) return;
                        this.rows[this.activerow].Active--;
                    } else {
                        if (this.rows[this.activerow].Color <= 0) return;
                        this.rows[this.activerow].Color--;
                    }
                } else {
                    if (!this.colorChoose) {
                        if (this.rows[this.activerow].Active + 1 > this.rows[this.activerow].MaxData[this.sex]) return;
                        this.rows[this.activerow].Active++;
                    } else {
                        this.rows[this.activerow].Color++;
                    }
                }
            } else if (this.rows[this.activerow].Type === TYPE_TOP_BINCO) {
                if (isLeft) {
                    if (!this.colorChoose) {
                        if (this.rows[this.activerow].Active - 1 < 0) return;
                        this.rows[this.activerow].Color = 0;
                        this.rows[this.activerow].Active--;
                    } else {
                        if (this.rows[this.activerow].Color - 1 < 0) return;
                        this.rows[this.activerow].Color--;
                    }
                } else {

                    if (!this.colorChoose) {
                        let aRow = this.rows[this.activerow];
                        if (aRow.Datas[this.sex][aRow.Active + 1] === undefined) return;
                        this.rows[this.activerow].Color = 0;
                        aRow.Active++;
                    } else {
                        let aRow = this.rows[this.activerow];
                        if (aRow.Datas[this.sex][aRow.Active].Textures[aRow.Color + 1] === undefined) return;
                        aRow.Color++;
                    }
                }
            }
            UpdateChar();
        },
        EnterKey: function() {
            if (!this.show) return;
            if (this.rows[this.activerow] === undefined) return;
            if (this.rows[this.activerow].Type !== TYPE_STANDARD &&
                this.rows[this.activerow].Type !== TYPE_STANDARD_SEX &&
                this.rows[this.activerow].Type !== TYPE_SUBMIT &&
                this.rows[this.activerow].Type !== TYPE_TOP_BINCO &&
                this.rows[this.activerow].Type !== TYPE_STANDARD_BINCO &&
                this.rows[this.activerow].Type !== TYPE_CANCEL) return;
            if ((this.rows[this.activerow].Type !== TYPE_SUBMIT && this.rows[this.activerow].Type !== TYPE_CANCEL) &&
                this.rows[this.activerow].Color === false) return;

            if (this.rows[this.activerow].Type === TYPE_SUBMIT) {
                UpdateChar(true);
            } else if (this.rows[this.activerow].Type === TYPE_CANCEL) {
                mp.trigger("creator.cancel", this.creatorType);
            } else {
                this.colorChoose = !this.colorChoose;
            }
        },
        SetGridPoint: function(progress) {
            if (!this.show) return;
            let v1 = 0;
            let v2 = 156;

            let newLeft = lerp(v1, v2, progress);
            $(".lsvrp-charcreator .grid .img .point").css({ left: newLeft });

            let aRow = this.rows[this.activerow];
            if (aRow === undefined) return;
            if (aRow.Type !== TYPE_CUSTOM) return;
            aRow.Value = parseFloat(parseFloat(progress).toFixed(2));
            UpdateChar();
        },
        ProgressToValue: function(row) {
            return lerp(row.Min, row.Max, row.Value).toFixed(2);
        }
    }
});

function lerp(value1, value2, amount) {
    amount = amount < 0 ? 0 : amount;
    amount = amount > 1 ? 1 : amount;
    return value1 + (value2 - value1) * amount;
}

$(function() {
    $(document).keydown(function(e) {
        if (e.which === 37) lsvrpVueCharCreator.HorizontalKey(true); // LEWO
        else if (e.which === 38) lsvrpVueCharCreator.VerticalKey(true); // GORA
        else if (e.which === 39) lsvrpVueCharCreator.HorizontalKey(false); // PRAWO
        else if (e.which === 40) lsvrpVueCharCreator.VerticalKey(false); // DOL
        else if (e.which === 13) lsvrpVueCharCreator.EnterKey(); // ENTER

        if (e.which > 36 && e.which < 41) e.preventDefault();
    });

    $(".lsvrp-charcreator .grid").mousedown(function(e) {
        if (e.which !== 1) return;
        lsvrpVueCharCreator.grid.mouseClicked = true;
        let lPos = e.pageX - $(".lsvrp-charcreator .grid .img").offset().left - 6;
        if (lPos < 0 || lPos > 156) return;
        let progress = lPos / 156;

        lsvrpVueCharCreator.SetGridPoint(progress);
    });

    $(".lsvrp-charcreator .grid").mousemove(function(e) {
        if (!lsvrpVueCharCreator.grid.mouseClicked) return;
        let lPos = e.pageX - $(".lsvrp-charcreator .grid .img").offset().left - 6;
        let progress = lPos / 156;
        if (progress < 0) progress = 0;
        if (progress > 1) progress = 1;

        lsvrpVueCharCreator.SetGridPoint(progress);
    });

    $(document).mouseup(function(e) {
        if (!lsvrpVueCharCreator.grid.mouseClicked) return;
        lsvrpVueCharCreator.grid.mouseClicked = false;
    });

});

// RAGE
function ToggleCharCreator(state, cType = 0, sex = SEX_MALE) {
    if (state) {
        lsvrpVueCharCreator.creatorType = cType;
        if (cType === CREATOR_TYPE_FULL) {
            lsvrpVueCharCreator.rows = JSON.parse(JSON.stringify(CREATOR_DATA_FULL));
        } else if (cType === CREATOR_TYPE_BINCO) {
            lsvrpVueCharCreator.rows = JSON.parse(JSON.stringify(CREATOR_DATA_BINCO));
        }

        lsvrpVueCharCreator.activerow = 0;
        lsvrpVueCharCreator.sex = sex;
    }

    lsvrpVueCharCreator.show = state;
}

function UpdateChar(withSave = false) {
    if (lsvrpVueCharCreator.creatorType === CREATOR_TYPE_FULL) {
        let output = {
            Zarost: lsvrpVueCharCreator.rows[CreatorData.Zarost].Datas[lsvrpVueCharCreator.rows[CreatorData.Zarost]
                .Active].Value,
            ZarostKolor: lsvrpVueCharCreator.rows[CreatorData.Zarost].Color,
            Wlosy: lsvrpVueCharCreator.rows[CreatorData.Wlosy].Datas[lsvrpVueCharCreator.sex][
                lsvrpVueCharCreator.rows[CreatorData.Wlosy].Active].Value,
            WlosyKolor: lsvrpVueCharCreator.rows[CreatorData.Wlosy].Color,
            Brwi: lsvrpVueCharCreator.rows[CreatorData.Brwi].Datas[lsvrpVueCharCreator.rows[CreatorData.Brwi].Active]
                .Value,
            BrwiKolor: lsvrpVueCharCreator.rows[CreatorData.Brwi].Color,
            Blizny: lsvrpVueCharCreator.rows[CreatorData.Blizny].Datas[lsvrpVueCharCreator.rows[CreatorData.Blizny]
                .Active].Value,
            Postarzanie: lsvrpVueCharCreator.rows[CreatorData.Postarzanie].Datas[lsvrpVueCharCreator.rows[CreatorData
                .Postarzanie].Active].Value,
            Makijaz: lsvrpVueCharCreator.rows[CreatorData.Makijaz].Datas[lsvrpVueCharCreator.rows[CreatorData.Makijaz]
                .Active].Value,
            Rumieniec: lsvrpVueCharCreator.rows[CreatorData.Rumieniec].Datas[lsvrpVueCharCreator.rows[CreatorData
                .Rumieniec].Active].Value,
            RumieniecKolor: lsvrpVueCharCreator.rows[CreatorData.Rumieniec].Color,
            Cera: lsvrpVueCharCreator.rows[CreatorData.Cera].Datas[lsvrpVueCharCreator.rows[CreatorData.Cera].Active]
                .Value,
            Oparzenia: lsvrpVueCharCreator.rows[CreatorData.Oparzenia].Datas[lsvrpVueCharCreator.rows[CreatorData
                .Oparzenia].Active].Value,
            Pomadka: lsvrpVueCharCreator.rows[CreatorData.Pomadka].Datas[lsvrpVueCharCreator.rows[CreatorData.Pomadka]
                .Active].Value,
            PomadkaKolor: lsvrpVueCharCreator.rows[CreatorData.Pomadka].Color,
            Piegi: lsvrpVueCharCreator.rows[CreatorData.Piegi].Datas[lsvrpVueCharCreator.rows[CreatorData.Piegi].Active]
                .Value,
            Owlosienie: lsvrpVueCharCreator.rows[CreatorData.Owlosienie].Datas[lsvrpVueCharCreator.rows[CreatorData
                .Owlosienie].Active].Value,
            OwlosienieKolor: lsvrpVueCharCreator.rows[CreatorData.Owlosienie].Color,
            SzerNos: lsvrpVueCharCreator.ProgressToValue(lsvrpVueCharCreator.rows[CreatorData.SzerNos]),
            WysNos: lsvrpVueCharCreator.ProgressToValue(lsvrpVueCharCreator.rows[CreatorData.WysNos]),
            DlNos: lsvrpVueCharCreator.ProgressToValue(lsvrpVueCharCreator.rows[CreatorData.DlNos]),
            MosNos: lsvrpVueCharCreator.ProgressToValue(lsvrpVueCharCreator.rows[CreatorData.MosNos]),
            KonNos: lsvrpVueCharCreator.ProgressToValue(lsvrpVueCharCreator.rows[CreatorData.KonNos]),
            PrzesNos: lsvrpVueCharCreator.ProgressToValue(lsvrpVueCharCreator.rows[CreatorData.PrzesNos]),
            WysBrwi: lsvrpVueCharCreator.ProgressToValue(lsvrpVueCharCreator.rows[CreatorData.WysBrwi]),
            SzerBrwi: lsvrpVueCharCreator.ProgressToValue(lsvrpVueCharCreator.rows[CreatorData.SzerBrwi]),
            WysKos: lsvrpVueCharCreator.ProgressToValue(lsvrpVueCharCreator.rows[CreatorData.WysKos]),
            SzerKos: lsvrpVueCharCreator.ProgressToValue(lsvrpVueCharCreator.rows[CreatorData.SzerKos]),
            SzerPol: lsvrpVueCharCreator.ProgressToValue(lsvrpVueCharCreator.rows[CreatorData.SzerPol]),
            SzerOcz: lsvrpVueCharCreator.ProgressToValue(lsvrpVueCharCreator.rows[CreatorData.SzerOcz]),
            SzerUst: lsvrpVueCharCreator.ProgressToValue(lsvrpVueCharCreator.rows[CreatorData.SzerUst]),
            SzerSzcz: lsvrpVueCharCreator.ProgressToValue(lsvrpVueCharCreator.rows[CreatorData.SzerSzcz]),
            WysSzcz: lsvrpVueCharCreator.ProgressToValue(lsvrpVueCharCreator.rows[CreatorData.WysSzcz]),
            DlPodbr: lsvrpVueCharCreator.ProgressToValue(lsvrpVueCharCreator.rows[CreatorData.DlPodbr]),
            PozPodbr: lsvrpVueCharCreator.ProgressToValue(lsvrpVueCharCreator.rows[CreatorData.PozPodbr]),
            SzerPodbr: lsvrpVueCharCreator.ProgressToValue(lsvrpVueCharCreator.rows[CreatorData.SzerPodbr]),
            KsztPodbr: lsvrpVueCharCreator.ProgressToValue(lsvrpVueCharCreator.rows[CreatorData.KsztPodbr]),
            DlSzyi: lsvrpVueCharCreator.ProgressToValue(lsvrpVueCharCreator.rows[CreatorData.DlSzyi]),
            MieszSkin: lsvrpVueCharCreator.ProgressToValue(lsvrpVueCharCreator.rows[CreatorData.MieszSkin]),
            MieszKolor: lsvrpVueCharCreator.ProgressToValue(lsvrpVueCharCreator.rows[CreatorData.MieszKolor]),
            Matka: lsvrpVueCharCreator.rows[CreatorData.Matka].Datas[lsvrpVueCharCreator.rows[CreatorData.Matka].Active]
                .Value,
            Ojciec: lsvrpVueCharCreator.rows[CreatorData.Ojciec].Datas[lsvrpVueCharCreator.rows[CreatorData.Ojciec]
                .Active].Value
        };

        if (!withSave) {
            mp.trigger("creator.UpdateChar", JSON.stringify(output));
        } else {
            mp.trigger("creator.saveChar", JSON.stringify(output));
        }
    } else if (lsvrpVueCharCreator.creatorType === CREATOR_TYPE_BINCO) {

        let output = {
            Top: lsvrpVueCharCreator.rows[BincoData.Top].Datas[lsvrpVueCharCreator.sex][
                lsvrpVueCharCreator.rows[BincoData.Top].Active].Value,
            TopColor: lsvrpVueCharCreator.rows[BincoData.Top].Datas[lsvrpVueCharCreator.sex][
                lsvrpVueCharCreator.rows[BincoData.Top].Active].Textures[lsvrpVueCharCreator.rows[BincoData.Top].Color],
            Torso: lsvrpVueCharCreator.rows[BincoData.Top].Datas[lsvrpVueCharCreator.sex][
                lsvrpVueCharCreator.rows[BincoData.Top].Active].Torso,

            Undershirt: lsvrpVueCharCreator.rows[BincoData.Undershirt].Datas[lsvrpVueCharCreator.sex][
                lsvrpVueCharCreator.rows[BincoData.Undershirt].Active].Value,
            UndershirtColor:
                lsvrpVueCharCreator.rows[BincoData.Undershirt].Datas[lsvrpVueCharCreator.sex][
                        lsvrpVueCharCreator.rows[BincoData.Undershirt].Active]
                    .Textures[lsvrpVueCharCreator.rows[BincoData.Undershirt].Color],

            Legs: lsvrpVueCharCreator.rows[BincoData.Legs].Datas[lsvrpVueCharCreator.sex][
                lsvrpVueCharCreator.rows[BincoData.Legs].Active].Value,
            LegsColor: lsvrpVueCharCreator.rows[BincoData.Legs].Datas[lsvrpVueCharCreator.sex][
                    lsvrpVueCharCreator.rows[BincoData.Legs].Active]
                .Textures[lsvrpVueCharCreator.rows[BincoData.Legs].Color],

            Boots: lsvrpVueCharCreator.rows[BincoData.Boots].Datas[lsvrpVueCharCreator.sex][
                lsvrpVueCharCreator.rows[BincoData.Boots].Active].Value,
            BootsColor: lsvrpVueCharCreator.rows[BincoData.Boots].Datas[lsvrpVueCharCreator.sex][
                    lsvrpVueCharCreator.rows[BincoData.Boots].Active]
                .Textures[lsvrpVueCharCreator.rows[BincoData.Boots].Color],


            // Undershirt: lsvrpVueCharCreator.rows[BincoData.Undershirt].Datas[lsvrpVueCharCreator.sex][lsvrpVueCharCreator.rows[BincoData.Undershirt].Active].Value,
            // UndershirtColor: lsvrpVueCharCreator.rows[BincoData.Undershirt].Datas[lsvrpVueCharCreator.sex][lsvrpVueCharCreator.rows[BincoData.Undershirt].Active].Textures[lsvrpVueCharCreator.rows[BincoData.Undershirt].Color],
        };

        if (!withSave) {
            mp.trigger("creator.UpdateBinco", JSON.stringify(output));
        } else {
            mp.trigger("creator.SaveBinco", JSON.stringify(output));
        }


    }

    // console.log(JSON.stringify(output));

}