import dumpImg from "../assets/dump_img.webp";

export function getSrc([...images]) {
    let listSrc = images.filter(image => image)
    if (listSrc.length > 0) {
        return listSrc[0]
    } else {
        return dumpImg;
    }
};