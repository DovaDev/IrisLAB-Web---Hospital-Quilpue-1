declare var numeral: (num: number | string) => numeral_main

declare module "numeral" {
    export = numeral;
}

interface numeral_main {
    format: (str: string) => string;
}