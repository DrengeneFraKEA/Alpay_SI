import os
import xml.etree.ElementTree as ET
import yaml
import json
import csv

def read_text_file(file_path):
    with open(file_path, 'r', encoding='utf-8-sig') as file:
        lines = file.read().split(':')
    return lines

def read_xml_file(file_path):
    tree = ET.parse(file_path)
    root = tree.getroot()
    return {elem.tag: elem.text for elem in root.findall('*')}

def read_yaml_file(file_path):
    with open(file_path, 'r', encoding='utf-8-sig') as file:
        yaml_data = yaml.safe_load(file)
    return yaml_data

def read_json_file(file_path):
    with open(file_path, 'r', encoding='utf-8-sig') as file:
        json_text = file.read()
        json_data = json.loads(json_text)
    return json_data

def read_csv_file(file_path):
    with open(file_path, 'r', encoding='utf-8-sig') as file:
        csv_reader = csv.reader(file)
        data = [row for row in csv_reader]
    return data

if __name__ == "__main__":
    # File path
    files_dir = os.path.join(os.path.dirname(os.path.abspath(__file__)), "files")

    # Text
    text_lines = read_text_file(os.path.join(files_dir, "txt.txt"))

    # XML
    xml_data = read_xml_file(os.path.join(files_dir, "xml.xml"))

    # YAML
    yaml_data = read_yaml_file(os.path.join(files_dir, "yaml.yaml"))

    # JSON
    json_data = read_json_file(os.path.join(files_dir, "json.json"))

    # CSV
    csv_data = read_csv_file(os.path.join(files_dir, "csv.csv"))

    # Prints
    print("Text:", text_lines)
    print("XML:", csv_data)
    print("YAML:", yaml_data)
    print("JSON:", json_data)
    print("CSV:", csv_data)
