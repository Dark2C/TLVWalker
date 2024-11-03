# TLV Walker

## Overview
**TLV Walker** is a Windows Forms application designed to help users navigate and interpret TLV (Tag-Length-Value) encoded data. TLV encoding is a structured format used to store data, where each piece is prefixed with a tag identifying the data type, followed by the length of the data, and finally the value itself.

## What is TLV?
**TLV** stands for **Tag-Length-Value**:
- **Tag**: A unique identifier for the data type.
- **Length**: The size of the data value.
- **Value**: The actual data.

This encoding format is commonly used in various communication protocols and data storage systems to ensure that data can be easily parsed and interpreted.

## Features

### File Handling
- **Open TLV Files**: Open TLV-encoded files using a file dialog. The application reads the file in binary mode and processes the TLV data.
- **Import/Export Tag Decoding Schema**: Import and export the tag decoding schema to and from JSON files for easy sharing and reuse.

### Tree View Management
- **Visualize TLV Structure**: Displays the hierarchical structure of TLV data in a tree view for easy navigation through nested tags and values.
- **Expand/Collapse Nodes**: Expand and collapse nodes in the tree view to explore the TLV data hierarchy.

### TLV Parsing
- **Tag Management**: Manage tags and specify whether a tag represents a directory or a file.

### UI Interactions
- **Node Selection**: Displays details about the selected tag, including its hexadecimal representation and textual content.
- **Preview Data**: Preview the first 100 bytes of the tag's value in both hexadecimal and text formats, or view the entire value.

## Getting Started
1. **Open a TLV File**: Click on the "Open" menu item to select and open a TLV-encoded file.
2. **Navigate the Tree View**: Explore the hierarchical structure of the TLV data using the tree view.
3. **View Tag Details**: Select a node in the tree view to see detailed information about the tag and its value.
4. **Manage Tags**: Use the provided options to import/export tag decoding schemas and specify whether tags are directories or files.

## Requirements
- Windows operating system
- .NET Framework

## Installation
1. Clone the repository to your local machine.
2. Open the solution in Visual Studio.
3. Build and run the application.


Alternatively, you can find a precompiled version in the `release.7z` file.